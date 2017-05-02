using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    //private int Lives = 3;
    private int counter;
    private Text theText;
    // Use this for initialization
    void Start()
    {
        Debug.Log("Class");
        theText = GetComponent<Text>();
        counter = PlayerPrefs.GetInt("PlayerCurrentLives");
    }

    // Update is called once per frame
    void Update()
    {
        if (counter >= 0)
        {
            theText.text = "x " + counter;
        }

    }

    public void TakeLife()
    {
        counter--;
        PlayerPrefs.SetInt("PlayerCurrentLives", counter);
    }

    public int currentLives()
    {
        return counter;
    }
}