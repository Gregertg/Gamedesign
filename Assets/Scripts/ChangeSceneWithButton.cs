using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneWithButton : MonoBehaviour
{
    public Animator transition;

    public void update(){
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex +1));
    }


    public IEnumerator LoadLevel(int levelIndex){
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(4);

        SceneManager.LoadScene(levelIndex);
    }
}



