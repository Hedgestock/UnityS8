using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PickUpCollectibles : MonoBehaviour
{

    public Camera playerCam;
    public Text scoreText;
    public Slider carSlider;

    private RaycastHit hit;
    private int score = 0;
    private int carScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Main")
        {
            score = 0;
            scoreText.text = "Score = " + score;
        }
        else
        {
            score = PlayerPrefs.GetInt("score");
            scoreText.text = "Score = " + score;
        }
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
            }
        }
    }

    void score_up(GameObject other)
    {
        score += ((Trash) other.GetComponent(typeof(Trash))).Value;
        scoreText.text = "Score = " + score;
        if (other.tag == "Car_Trash")
        {
            carSlider.value++;
        }
        PlayerPrefs.SetInt("score", score);
    }
}
