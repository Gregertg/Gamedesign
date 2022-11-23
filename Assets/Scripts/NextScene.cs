using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public void LoadNextLevel(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
}
