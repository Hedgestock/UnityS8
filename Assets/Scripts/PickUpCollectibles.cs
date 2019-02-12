using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCollectibles : MonoBehaviour
{

    public Camera playerCam;

    private RaycastHit hit;

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
            Debug.Log("Clicked");
            Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);
            GameObject other = hit.collider.transform.root.gameObject;
            Debug.Log(other);
            if (other.layer == LayerMask.NameToLayer("Collectible"))
            {
                Destroy(other);
                Debug.Log("Destroyed");
            }
        }
    }

    void OnMouseDown()
    {
        Debug.Log("Clicked");
        Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
        GameObject other = hit.collider.gameObject;
        if (other.layer == LayerMask.NameToLayer("Collectible"))
        {
            Destroy(other);
            Debug.Log("Destroyed");
        }
    }
}
