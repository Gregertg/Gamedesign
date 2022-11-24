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

    public GameObject roNedGuard1;
    public GameObject vannGuard1;
    public GameObject rundeGuard1;

    public GameObject roNedGuard2;
    public GameObject vannGuard2;
    public GameObject rundeGuard2;

    public GameObject roNedGuard3;
    public GameObject vannGuard3;
    public GameObject rundeGuard3;

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
    
    public Sprite byNightStorsalen;
    public GameObject byDayStorsalen;
    public Sprite byNightEdgar;
    public GameObject byDayEdgar;
    public Sprite byNightRundhallen;
    public GameObject byDayRundhallen;
    private float timer = 1380.0f; //how long since the timer "started"

    public ParticleSystem dust;
    // Start is called before the first frame update
    void Start()
    {
       playerDrunkenness = GameObject.FindGameObjectWithTag("Player").GetComponent<Drunkenness>();
       rb = gameObject.GetComponent<Rigidbody2D>();
       PlayerPrefs.SetFloat("Score", 0);
       friends = 0;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;  
        speed = 5.0f;
        // Skal endre betingelsene når jeg får implementert øl. Dette er bare for å sjekke at det funker
        if(playerDrunkenness.curDrunkenness < 17){
            speed = 2.0f;
        }

        if(playerDrunkenness.curDrunkenness >= 80){
            if(Input.GetKey(KeyCode.UpArrow)){
                transform.Translate(0,-speed * Time.deltaTime,0);
                animator.SetFloat("Horizontal", 1);
                CreateDust();
        }
            if(Input.GetKey(KeyCode.DownArrow)){
                transform.Translate(0,speed * Time.deltaTime,0);
                animator.SetFloat("Horizontal", 1);
                CreateDust();
            }
            if(Input.GetKey(KeyCode.LeftArrow)){
                animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
                transform.Translate(speed * Time.deltaTime,0,0);
                right = true;
                CreateDust();
                //gameObject.transform.localScale = new Vector3(1.2f,1.2f,1);
        }
            if(Input.GetKey(KeyCode.RightArrow)){
                animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
                transform.Translate(-speed * Time.deltaTime,0,0);
                gameObject.transform.localScale = new Vector3(-0.3f,0.3f,1);
                right = false;
                CreateDust();
        }
        }
        
        else{
            if(Input.GetKey(KeyCode.UpArrow)){
                transform.Translate(0,speed * Time.deltaTime,0);
                animator.SetFloat("Horizontal", 1);
                CreateDust();
            }
            if(Input.GetKey(KeyCode.DownArrow)){
                transform.Translate(0,-speed * Time.deltaTime,0);
                animator.SetFloat("Horizontal", 1);
                CreateDust();
            }
            if(Input.GetKey(KeyCode.LeftArrow)){
                //animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
                transform.Translate(-speed * Time.deltaTime,0,0);
                gameObject.transform.localScale = new Vector3(-0.3f,0.3f,1);
                right = false;
                CreateDust();
            }
            if(Input.GetKey(KeyCode.RightArrow)){
                animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
                transform.Translate(speed * Time.deltaTime,0,0);
                gameObject.transform.localScale = new Vector3(0.3f,0.3f,1);
                right = true;
                CreateDust();
            }

        }
        if(!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow)){
            animator.SetFloat("Horizontal", 0);
            if(right == false && playerDrunkenness.curDrunkenness >= 70){
                gameObject.transform.localScale = new Vector3(-0.3f,0.3f,0.001f);
            }else if(right == true && playerDrunkenness.curDrunkenness >= 70){
                gameObject.transform.localScale = new Vector3(0.3f,0.3f,0.001f);
            }else if(right == false && playerDrunkenness.curDrunkenness < 70){
                gameObject.transform.localScale = new Vector3(-0.3f,0.3f,0.001f);
            }else if(right == true && playerDrunkenness.curDrunkenness < 70){
                gameObject.transform.localScale = new Vector3(0.3f,0.3f,0.001f);
            }
        }
        if(timer > 1500.0f){
            byDayStorsalen.GetComponent<SpriteRenderer>().sprite = byNightStorsalen;
            byDayEdgar.GetComponent<SpriteRenderer>().sprite = byNightEdgar;
            byDayRundhallen.GetComponent<SpriteRenderer>().sprite = byNightRundhallen;
        }

    }

           public IEnumerator GenerateObjects(){
                objectToGenerate = Random.Range(1,4);
                room = Random.Range(1,4);

                if(room == 1){
                    xPos = Random.Range(-13,6);
                    yPos = Random.Range(21,31);
                    
                }else if(room == 2){
                    xPos = Random.Range(22,48);
                    yPos = Random.Range(23,29); 
                }else if(room == 3){
                    xPos = Random.Range(-15,8);
                    yPos = Random.Range(-4,5);  
                }
                while(Physics2D.OverlapCircle(new Vector2(xPos,yPos),0.5f)){
                    if(room == 1){
                        xPos = Random.Range(-13,6);
                        yPos = Random.Range(21,31);
                    }else if(room == 2){
                        xPos = Random.Range(22,48);
                        yPos = Random.Range(23,29);
                    }else if(room == 3){
                        xPos = Random.Range(-15,8);
                        yPos = Random.Range(-4,5);   
                    }
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
                    xPos = Random.Range(-13,6);
                    yPos = Random.Range(21,31);
                }else if(room == 2){
                    xPos = Random.Range(22,48);
                    yPos = Random.Range(23,29); 
                }else if(room == 3){
                    xPos = Random.Range(-15,8);
                    yPos = Random.Range(-4,5);  
                }
                while(Physics2D.OverlapCircle(new Vector2(xPos,yPos),0.2f)){
                    if(room == 1){
                        xPos = Random.Range(-13,6);
                        yPos = Random.Range(21,31);
                    }else if(room == 2){
                        xPos = Random.Range(22,48);
                        yPos = Random.Range(23,29);
                    }else if(room == 3){
                        xPos = Random.Range(-15,8);
                        yPos = Random.Range(-4,5);   
                    }
                }
                Instantiate(firstBeer, new Vector3(xPos, yPos, 0), Quaternion.identity);
                
                yield return new WaitForSeconds(0.1f);
            }


    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Friends"){
            friends++;
            friendsAmount.text = ": " + friends;
            PlayerPrefs.SetFloat("Score", friends);
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
        if(collision.gameObject.tag == "moveScene"){
            SceneManager.LoadScene ("SampleScene");
        }

        // Her begynner Guard-kjøret

        if(collision.gameObject.tag == "Guards" && playerDrunkenness.curDrunkenness >= 70){
            SceneManager.LoadScene("YouLost");
        }

        // Guard 1 (Rundhallen)
        if(collision.gameObject.tag == "Guards" && GameObject.Find("Guard") && playerDrunkenness.curDrunkenness < 70 && playerDrunkenness.curDrunkenness >= 50){
            rundeGuard1 = GameObject.FindGameObjectWithTag("TextBubble3");
            SpriteRenderer text3Guard1 = rundeGuard1.GetComponent<SpriteRenderer>();
            text3Guard1.enabled = true;
            StartCoroutine(textBubble3Coroutine());

            IEnumerator textBubble3Coroutine()
                {
                    //yield on a new YieldInstruction that waits for 5 seconds.
                    yield return new WaitForSeconds(5);
                    text3Guard1.enabled = false;
                }
        }
        if(collision.gameObject.tag == "Guards" && GameObject.Find("Guard") && playerDrunkenness.curDrunkenness < 50 && playerDrunkenness.curDrunkenness >= 20){
            roNedGuard1 = GameObject.FindGameObjectWithTag("TextBubble");
            SpriteRenderer text1Guard1 = roNedGuard1.GetComponent<SpriteRenderer>();
            text1Guard1.enabled = true;
            StartCoroutine(textBubbleCoroutine());

            IEnumerator textBubbleCoroutine()
                {
                    //yield on a new YieldInstruction that waits for 5 seconds.
                    yield return new WaitForSeconds(5);
                    text1Guard1.enabled = false;
                }
        }
        if(collision.gameObject.tag == "Guards" && GameObject.Find("Guard") && playerDrunkenness.curDrunkenness < 20){
            vannGuard1 = GameObject.FindGameObjectWithTag("TextBubble2");
            SpriteRenderer text2Guard1 = vannGuard1.GetComponent<SpriteRenderer>();
            text2Guard1.enabled = true;
            StartCoroutine(textBubble2Coroutine());

            IEnumerator textBubble2Coroutine()
                {
                    //yield on a new YieldInstruction that waits for 5 seconds.
                    yield return new WaitForSeconds(5);
                    text2Guard1.enabled = false;
                }
        }

        // Guard 2 (Edgar)
        if(collision.gameObject.tag == "Guards" && GameObject.Find("Guard (1)") && playerDrunkenness.curDrunkenness < 70 && playerDrunkenness.curDrunkenness >= 50){
            rundeGuard2 = GameObject.FindGameObjectWithTag("TextBubble5");
            SpriteRenderer text3Guard2 = rundeGuard2.GetComponent<SpriteRenderer>();
            text3Guard2.enabled = true;
            StartCoroutine(textBubble3Coroutine());

            IEnumerator textBubble3Coroutine()
                {
                    //yield on a new YieldInstruction that waits for 5 seconds.
                    yield return new WaitForSeconds(5);
                    text3Guard2.enabled = false;
                }
        }
        if(collision.gameObject.tag == "Guards" && GameObject.Find("Guard (1)") && playerDrunkenness.curDrunkenness < 50 && playerDrunkenness.curDrunkenness >= 20){
            roNedGuard2 = GameObject.FindGameObjectWithTag("TextBubble4");
            SpriteRenderer text1Guard2 = roNedGuard2.GetComponent<SpriteRenderer>();
            text1Guard2.enabled = true;
            StartCoroutine(textBubbleCoroutine());

            IEnumerator textBubbleCoroutine()
                {
                    //yield on a new YieldInstruction that waits for 5 seconds.
                    yield return new WaitForSeconds(5);
                    text1Guard2.enabled = false;
                }
        }
        if(collision.gameObject.tag == "Guards" && GameObject.Find("Guard (1)") && playerDrunkenness.curDrunkenness < 20){
            vannGuard2 = GameObject.FindGameObjectWithTag("TextBubble6");
            SpriteRenderer text2Guard2 = vannGuard2.GetComponent<SpriteRenderer>();
            text2Guard2.enabled = true;
            StartCoroutine(textBubble2Coroutine());

            IEnumerator textBubble2Coroutine()
                {
                    //yield on a new YieldInstruction that waits for 5 seconds.
                    yield return new WaitForSeconds(5);
                    text2Guard2.enabled = false;
                }
        }

        // Guard 3 (Storsalen)
        if(collision.gameObject.tag == "Guards" && GameObject.Find("Guard (2)") && playerDrunkenness.curDrunkenness < 70 && playerDrunkenness.curDrunkenness >= 50){
            rundeGuard3 = GameObject.FindGameObjectWithTag("TextBubble8");
            SpriteRenderer text3Guard3 = rundeGuard3.GetComponent<SpriteRenderer>();
            text3Guard3.enabled = true;
            StartCoroutine(textBubble3Coroutine());

            IEnumerator textBubble3Coroutine()
                {
                    //yield on a new YieldInstruction that waits for 5 seconds.
                    yield return new WaitForSeconds(5);
                    text3Guard3.enabled = false;
                }
        }
        if(collision.gameObject.tag == "Guards" && GameObject.Find("Guard (2)") && playerDrunkenness.curDrunkenness < 50 && playerDrunkenness.curDrunkenness >= 20){
            roNedGuard3 = GameObject.FindGameObjectWithTag("TextBubble7");
            SpriteRenderer text1Guard3 = roNedGuard3.GetComponent<SpriteRenderer>();
            text1Guard3.enabled = true;
            StartCoroutine(textBubbleCoroutine());

            IEnumerator textBubbleCoroutine()
                {
                    //yield on a new YieldInstruction that waits for 5 seconds.
                    yield return new WaitForSeconds(5);
                    text1Guard3.enabled = false;
                }
        }
        if(collision.gameObject.tag == "Guards" && GameObject.Find("Guard (2)") && playerDrunkenness.curDrunkenness < 20){
            vannGuard3 = GameObject.FindGameObjectWithTag("TextBubble9");
            SpriteRenderer text2Guard3 = vannGuard3.GetComponent<SpriteRenderer>();
            text2Guard3.enabled = true;
            StartCoroutine(textBubble2Coroutine());

            IEnumerator textBubble2Coroutine()
                {
                    //yield on a new YieldInstruction that waits for 5 seconds.
                    yield return new WaitForSeconds(5);
                    text2Guard3.enabled = false;
                }
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

    void CreateDust(){
        dust.Play();
    }
}