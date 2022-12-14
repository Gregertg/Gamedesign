using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tid : MonoBehaviour
{
    public TMP_Text textTimer;
    private float timer = 1380.0f; //how long since the timer "started"
    //Set this in the Inspector
    public GameObject byDay;

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;   
        DisplayTid();
        if (timer > 1440){
            timer = 0.0f;
        }   
        if(timer > 120.0f && timer < 120.5f){
            SceneManager.LoadScene("YouWon");
        }
    }

    void DisplayTid(){
        int minutes = Mathf.FloorToInt(timer/60.0f);
        int seconds = Mathf.FloorToInt(timer - minutes*60);
        textTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
