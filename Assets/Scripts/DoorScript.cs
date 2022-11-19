using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] Transform posToGo;
    bool playerDetected;
    GameObject playerGO;
    // Start is called before the first frame update
    void Start()
    {
        playerDetected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerDetected){
            playerGO.transform.position = posToGo.position;
            playerDetected = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            playerDetected = true;
            playerGO = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            playerDetected = false;
        }
    }
}
