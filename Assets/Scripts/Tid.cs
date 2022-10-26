using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tid : MonoBehaviour
{

    public TMP_Text textTimer;
    private float timer = 1420.0f; //how long since the timer "started"
    private bool isTimer = false;
 
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        DisplayTid();
        if (timer == 1440){
            timer = 0.0f;
        }
    }

    void DisplayTid(){
        int minutes = Mathf.FloorToInt(timer/60.0f);
        int seconds = Mathf.FloorToInt(timer - minutes*60);
        textTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
