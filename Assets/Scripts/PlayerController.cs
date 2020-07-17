using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float Speed = 15f;
    Rigidbody2D myRB;
    LifeKeeper lf;
    public float timeLeft = 30.0f;
    float horiz = 0;
    public AudioClip rockHit;
    public AudioClip bigRockHit;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            FindObjectOfType<LifeKeeper>().DecreaseLives();
            myAudio.PlayOneShot(rockHit);
            //myAudio.PlayOneShot(HitByRock);
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
            FindObjectOfType<LifeKeeper>().BigRock();
            myAudio.PlayOneShot(bigRockHit);
            myAudio.PlayOneShot(bigRockHit);
            lf.BigRock();
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
            if (lf.lives <= 0)
            {
                Destroy(gameObject);
            }
            else {
                timeLeft = 30;
            }
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
//<<<<<<< HEAD
            horiz -= 0.4f;
//=======
//>>>>>>> 915e2dc472e172da3ee29657628dd0c425b8026a
            transform.Rotate(0, 0, horiz);
            horiz = 0f;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
//<<<<<<< HEAD
            horiz += 0.4f;
//=======
//>>>>>>> 915e2dc472e172da3ee29657628dd0c425b8026a
            transform.Rotate(0, 0, horiz);
            horiz = 0f;
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {

            transform.position += transform.up * Time.deltaTime * Speed;

        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
           transform.position -= transform.up * Time.deltaTime * Speed / 100;

        }
    }
}
