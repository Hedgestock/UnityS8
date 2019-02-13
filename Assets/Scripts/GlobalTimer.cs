using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GlobalTimer : MonoBehaviour
{

    public Text timerText;
    public int timeLeft = 300;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LoseTime");
        Time.timeScale = 1; 
    }
    void Update()
    {
        string seconds = "";
        if (timeLeft % 60 < 10)
        {
            seconds += "0";
        }

        seconds += (timeLeft % 60).ToString();
        
        timerText.text = ("Time: " + timeLeft / 60 + ":" + seconds);
    }
    //Simple Coroutine
    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}