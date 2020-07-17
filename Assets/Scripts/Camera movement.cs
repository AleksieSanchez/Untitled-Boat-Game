using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramovement : MonoBehaviour
{
    // Start is called before the first frame update
    float horiz = 0;
    public float Speed = 15f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            horiz -= 0.2f;
            transform.Rotate(0, 0, horiz);
            horiz = 0f;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            horiz += 0.2f;
            transform.Rotate(0, 0, horiz);
            horiz = 0f;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.W))
        {
            {
                transform.position += transform.up * Time.deltaTime * Speed;
            }
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                transform.position -= transform.up * Time.deltaTime * Speed / 2;
            }
        }
    }
}
