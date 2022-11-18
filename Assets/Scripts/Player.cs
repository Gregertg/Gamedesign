using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5.0f;
    public int friends = 0;

    public Text friendsAmount;

    public GameObject firstFriend;
    public GameObject secondFriend;
    public GameObject thirdFriend;

    public GameObject firstBeer;
 
    public int xPos;
    public int yPos;

    public int room;
    public int objectToGenerate;
    public int objectQuantity;

    public Drunkenness playerDrunkenness;

    public AudioSource beerSource;
    public AudioSource friendSource;

    public Tid tid;

    bool facingRight = true;

    public Animator animator;

    bool right = true;
    // Start is called before the first frame update
    void Start()
    {
       playerDrunkenness = GameObject.FindGameObjectWithTag("Player").GetComponent<Drunkenness>();
       rb = gameObject.GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        // Skal endre betingelsene når jeg får implementert øl. Dette er bare for å sjekke at det funker
        if(playerDrunkenness.curDrunkenness <=20){
            speed = 2.0f;
        }

        if(playerDrunkenness.curDrunkenness >= 70){
            if(Input.GetKey(KeyCode.LeftArrow)){
                animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
                transform.Translate(speed * Time.deltaTime,0,0);
                right = true;
                //gameObject.transform.localScale = new Vector3(1.2f,1.2f,1);
        }
            if(Input.GetKey(KeyCode.RightArrow)){
                animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
                transform.Translate(-speed * Time.deltaTime,0,0);
                gameObject.transform.localScale = new Vector3(-1.2f,1.2f,1);
                right = false;
        }
            if(Input.GetKey(KeyCode.UpArrow)){
                transform.Translate(0,-speed * Time.deltaTime,0);
        }
            if(Input.GetKey(KeyCode.DownArrow)){
                transform.Translate(0,speed * Time.deltaTime,0);
        }
        }
        
        else{
            if(Input.GetKey(KeyCode.LeftArrow)){
                animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
                transform.Translate(-speed * Time.deltaTime,0,0);
                right = false;
                //gameObject.transform.localScale = new Vector3(-1.2f,1.2f,1);
            }
            if(Input.GetKey(KeyCode.RightArrow)){
                animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
                transform.Translate(speed * Time.deltaTime,0,0);
                gameObject.transform.localScale = new Vector3(1.2f,1.2f,1);
                right = true;
            }
            if(Input.GetKey(KeyCode.UpArrow)){
                transform.Translate(0,speed * Time.deltaTime,0);
            }
            if(Input.GetKey(KeyCode.DownArrow)){
                transform.Translate(0,-speed * Time.deltaTime,0);
            }
        }
        if(!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow)){
            animator.SetFloat("Horizontal", 0);
            if(right == false && playerDrunkenness.curDrunkenness >= 70){
                gameObject.transform.localScale = new Vector3(-1.2f,1.2f,1);
            }else if(right == true && playerDrunkenness.curDrunkenness >= 70){
                gameObject.transform.localScale = new Vector3(1.2f,1.2f,1);
            }else if(right == false && playerDrunkenness.curDrunkenness < 70){
                gameObject.transform.localScale = new Vector3(-1.2f,1.2f,1);
            }else if(right == true && playerDrunkenness.curDrunkenness < 70){
                gameObject.transform.localScale = new Vector3(1.2f,1.2f,1);
            }
        }
    }

            IEnumerator GenerateObjects(){
                objectToGenerate = Random.Range(1,4);
                room = Random.Range(1,4);
                if(room == 1){
                    xPos = Random.Range(-7,10);
                    yPos = Random.Range(-3,5);
                }else if(room == 2){
                    xPos = Random.Range(-2,16);
                    yPos = Random.Range(12,20); 
                }else if(room == 3){
                    xPos = Random.Range(-24,-7);
                    yPos = Random.Range(9,17);  
                }
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

            IEnumerator GenerateBeers(){
                room = Random.Range(1,4);
                if(room == 1){
                    xPos = Random.Range(-7,10);
                    yPos = Random.Range(-3,5);
                }else if(room == 2){
                    xPos = Random.Range(-2,16);
                    yPos = Random.Range(12,20); 
                }else if(room == 3){
                    xPos = Random.Range(-24,-7);
                    yPos = Random.Range(9,17);  
                }
                Instantiate(firstBeer, new Vector3(xPos, yPos, 0), Quaternion.identity);
                
                yield return new WaitForSeconds(0.1f);
            }


    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Friends"){
            friends++;
            friendsAmount.text = "Friends: " + friends;
            Destroy(collision.gameObject);
            StartCoroutine(GenerateObjects());
            friendSource.Play();
        }
        if(collision.gameObject.tag == "Beer"){
            playerDrunkenness.curDrunkenness += 20;
            Destroy(collision.gameObject);
            StartCoroutine(GenerateBeers());
            beerSource.Play();
        }
        if(collision.gameObject.tag == "Guards"){
            SceneManager.LoadScene("YouLost");
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

    void flip(){
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}


