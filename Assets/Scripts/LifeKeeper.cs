using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeKeeper : MonoBehaviour
{
    public int lives = 20;
    void Start()
    {
        GetComponent<Text>().text = lives.ToString();
    }

    public void DecreaseLives()
    {
        lives--;
        GetComponent<Text>().text = lives.ToString();
    }

    public void BigRock()
    {
        lives -= 5;
        GetComponent<Text>().text = lives.ToString();
    }

    public void IncreaseLives()
    {
        lives++;
        GetComponent<Text>().text = lives.ToString();
    }

    public void OtherBigRock()
    {
        lives -= 3;
        GetComponent<Text>().text = lives.ToString();
    }


}
