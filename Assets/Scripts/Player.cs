using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    public int friends = 0;

    public Text friendsAmount;

    public GameObject firstFriend;
    public GameObject secondFriend;
    public GameObject thirdFriend;
    public int xPos;
    public int yPos;
    public int objectToGenerate;
    public int objectQuantity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

// legge inn en timer og ha etter 1 min skal venstre pil bli høyre. etter to min skal speeden gå fort


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.Translate(-speed * Time.deltaTime,0,0);
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            transform.Translate(speed * Time.deltaTime,0,0);
        }
        if(Input.GetKey(KeyCode.UpArrow)){
            transform.Translate(0,speed * Time.deltaTime,0);
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            transform.Translate(0,-speed * Time.deltaTime,0);
        }
    }

            IEnumerator GenerateObjects(){
                objectToGenerate = Random.Range(1,4);
                xPos = Random.Range(-9,9);
                yPos = Random.Range(-4,4);
                if(objectToGenerate == 1){
                    Instantiate(firstFriend, new Vector3(xPos, yPos, 0), Quaternion.identity);
                }
                if(objectToGenerate == 2){
                    Instantiate(secondFriend, new Vector3(xPos, yPos, 0), Quaternion.identity);
                }
                if(objectToGenerate == 3){
                    Instantiate(thirdFriend, new Vector3(xPos, yPos, 0), Quaternion.identity);
                }
                yield return new WaitForSeconds(0.1f);
            }


    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Friends"){
            friends++;
            friendsAmount.text = "Friends: " + friends;
            Destroy(collision.gameObject);
            StartCoroutine(GenerateObjects());
        }
        if(collision.gameObject.tag == "Guards"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if(collision.gameObject.tag == "Walls"){
            if(Input.GetKey(KeyCode.LeftArrow)){
                transform.Translate(speed * Time.deltaTime,0,0);
        }
            if(Input.GetKey(KeyCode.RightArrow)){
                transform.Translate(-speed * Time.deltaTime,0,0);
        }
            if(Input.GetKey(KeyCode.UpArrow)){
                transform.Translate(0,-speed * Time.deltaTime,0);
        }
            if(Input.GetKey(KeyCode.DownArrow)){
                transform.Translate(0,speed * Time.deltaTime,0);
            }
        }
  
    }
}


