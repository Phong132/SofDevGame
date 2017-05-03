using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    //counts lives
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
        //updates lives every frame and displays it on the screen
        if (counter >= 0)
        {
            theText.text = "x " + counter;
        }

    }

    //takes a life when the player hits spikes and dies
    public void TakeLife()
    {
        //takes away a life
        counter--;

        //playerprefs is updated to the lower life count
        PlayerPrefs.SetInt("PlayerCurrentLives", counter);
    }

    public int currentLives()
    {
        //returns the number of lives that the player currently has
        return counter;
    }
}
