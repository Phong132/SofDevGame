using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public int playerLives;

    public int startScore;

    public void LoadScene(string name)
    {
        Application.LoadLevel(name);

        PlayerPrefs.SetInt("PlayerCurrentLives", playerLives);

        PlayerPrefs.SetInt("CurrentScore", startScore);
    }

    public void Exit()
    {
        Application.Quit();
    }
}