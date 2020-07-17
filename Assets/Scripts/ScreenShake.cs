using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private float shakeDuration = 0.0f;

    private float shakeMagnitude = 0.7f;

    private float dampingSpeed = 1.0f;

    Vector3 initialPosition;


    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

        if (shakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }
    }

    public void TriggerShake(float duration, float magnitude)
    {
        if ((magnitude > shakeMagnitude && shakeDuration > 0) || shakeDuration <= 0)
        {
            shakeMagnitude = magnitude;
        }
        shakeDuration = duration;
    }
}