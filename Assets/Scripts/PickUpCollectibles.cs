using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PickUpCollectibles : MonoBehaviour
{

    public Camera playerCam;
    public Text text;
    public Slider slider;

    private RaycastHit hit;
    private int score = 0;
    private int carScore = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, playerCam.ScreenPointToRay(Input.mousePosition).direction * 100, Color.green);
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);
            GameObject other = hit.collider.transform.root.gameObject;
            Debug.Log(other);
            if (other.layer == LayerMask.NameToLayer("Collectible"))
            {
                score_up(other);
                Destroy(other);
            }
        }
    }

    void score_up(GameObject other)
    {
        score += 1;
        text.text = "Score = " + score;
        Debug.Log(other.tag);
        if (other.tag == "Car_Trash")
        {
            slider.value++;
        }
    }
}
