using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PickUpCollectibles : MonoBehaviour
{

    public Camera playerCam;
    public Text scoreText;
    public Slider carSlider;
    public int solarScore = 3;

    private RaycastHit hit;
    private int score = 0;
    private int solarNum = 0;
    private int carScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SolarTimer");
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, playerCam.ScreenPointToRay(Input.mousePosition).direction * 100, Color.green);
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 10))
            {
                GameObject other = hit.collider.transform.root.gameObject;
                if (other.layer == LayerMask.NameToLayer("Collectible"))
                {
                    score_up(other);
                    Destroy(other);
                }
                if (other.layer == LayerMask.NameToLayer("SolarPanel"))
                {
                    if (other.GetComponent<SolarPanel>().build(ref score))
                    {
                        solarNum++;
                    }
                }
            }
        }
        scoreText.text = "Score = " + score;
    }

    void score_up(GameObject other)
    {
        score += ((Trash) other.GetComponent(typeof(Trash))).Value;
        if (other.tag == "Car_Trash")
        {
            carSlider.value++;
        }
    }

    IEnumerator SolarTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Debug.Log(solarNum);
            Debug.Log(solarScore);
            Debug.Log(score);
            score += solarNum * solarScore;
            Debug.Log(score);
        }
    }
}
