using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarPanel : MonoBehaviour
{

    public int cost = 15;
    public GameObject placeHolder;
    public GameObject panel;
    bool isActive = true;

    public bool build(ref int score)
    {
        if (score >= cost)
        {
            score -= cost;
            placeHolder.SetActive(false);
            panel.SetActive(true);
            isActive = false;
            return true;
        }
        return false;
    }
}
