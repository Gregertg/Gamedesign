using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Tid : MonoBehaviour
{

    public TMP_Text textTimer;
    public float timer = 1380.0f; //how long since the timer "started"

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;   
        DisplayTid();
        if(timer > 1460){
            SceneManager.LoadScene("YouWon");
        }
        if (timer > 1440){
            timer = 0.0f;
        }     
    }

    void DisplayTid(){
        int minutes = Mathf.FloorToInt(timer/60.0f);
        int seconds = Mathf.FloorToInt(timer - minutes*60);
        textTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
