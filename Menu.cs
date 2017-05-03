using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script used in Main Menu
public class Menu : MonoBehaviour
{
    
    public int playerLives;

    public int startScore;

//Function used by play button and High Score
    public void LoadScene(string name)
    {
        Application.LoadLevel(name);

        PlayerPrefs.SetInt("PlayerCurrentLives", playerLives);

        PlayerPrefs.SetInt("CurrentScore", startScore);
    }

//function used by exit button
//It only works when you build the game
    public void Exit()
    {
        Application.Quit();
    }
}
