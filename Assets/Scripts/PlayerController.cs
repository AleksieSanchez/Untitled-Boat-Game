using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float Speed = 10f;
    Rigidbody2D myRB;
    LifeKeeper lf;
    public float timeLeft = 30.0f;
    float horiz = 0;
    public AudioClip rockHit;
    AudioSource myAudio;
    public ScreenShake SS;

    // Start is called before the first frame update
    void Start()
    {
        
        myRB = GetComponent<Rigidbody2D>();
        lf = FindObjectOfType<LifeKeeper>();
        myAudio = GetComponent<AudioSource>();
        SS = FindObjectOfType<ScreenShake>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Rock"))
        {
            FindObjectOfType<LifeKeeper>().DecreaseLives();
            myAudio.PlayOneShot(rockHit);
            SS.TriggerShake(0.5f, 0.3f);
            Destroy(collision.gameObject);
            if (lf.lives <= 0)
            {
                Destroy(gameObject);
            }

        }
        else if (collision.gameObject.CompareTag("Winner"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Big"))
        {
            FindObjectOfType<LifeKeeper>().DecreaseLives();
            FindObjectOfType<LifeKeeper>().DecreaseLives();
            FindObjectOfType<LifeKeeper>().DecreaseLives();
            SS.TriggerShake(1f, 0.5f);
            Destroy(collision.gameObject);
            if (lf.lives <= 0)
            {
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("Plank"))
        {
            FindObjectOfType<LifeKeeper>().IncreaseLives();
            Destroy(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            lf.DecreaseLives();
            timeLeft = 30;
        }

        Vector2 movement = new Vector2();
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            horiz -= 0.1f;
            transform.Rotate(0, 0, horiz);
            horiz = 0f;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            horiz += 0.1f;
            transform.Rotate(0, 0, horiz);
            horiz = 0f;
        }


        movement.y = Input.GetAxisRaw("Vertical");
        //myRB.AddForce(movement.normalized * Speed);
        myRB.AddForce(movement.normalized * Speed * myRB.transform.forward);
        
        //myRB.AddForce(transform.forward.normalized * Speed);
        //myRB.velocity = transform.forward * Speed;
        //transform.Translate(transform.forward * acceleration * Time.deltaTime, Space.World);
        //Move with arrows
        /*
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            
        }
        */



        //old turn mechanics
        /*
        if (Input.GetKey("left"))
        {
            transform.Rotate(new Vector3(0, 0, Input.GetAxisRaw("Horizontal") * 1 / 10f));
        }
        else if (Input.GetKey("right"))
        {
            transform.Rotate(new Vector3(0, 0, Input.GetAxisRaw("Horizontal") * 1 / 10f));
        }

        Vector2 movement = new Vector2();
        movement.y = Input.GetAxisRaw("Vertical");

        myRB.AddForce(movement.normalized * Speed);
        */
    }
}
