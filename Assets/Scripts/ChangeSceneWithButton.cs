using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneWithButton : MonoBehaviour
{
    public Animator transition;
    //public float transitionTime = 30.0f;
    bool click = false;

/*
    public void LoadNextLevel(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
    void update(){
        if(Input.GetMouseButtonDown(0)){
            LoadNextLevel();
        }
    }
*/
    public void update(){
        bool click = true;
        print(click);
        print(click + "yo");
        if(click){
            print(click + "yo34");
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex +1));
            print(click + "yoyoyooyoy");
        }
    }



    public IEnumerator LoadLevel(int levelIndex){
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(5);

        SceneManager.LoadScene(levelIndex);
    }
}



