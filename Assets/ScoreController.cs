using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    public Text Score;

    private void Start(){
        //Score.text = Player.friends.ToString();
        Score.text = PlayerPrefs.GetFloat("Score").ToString();
        Debug.Log(PlayerPrefs.GetFloat("Score"));
    }
}
