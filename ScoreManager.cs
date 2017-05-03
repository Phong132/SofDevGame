using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    	//created integer score to keep track of score on this script
	public static int score;

	Text text;

	void Start()
	{
		text = GetComponent<Text> ();

        //score is set to playerprefs which constantly holds the current/updated score
        score = PlayerPrefs.GetInt("CurrentScore");
	}

    	//updates the score if called upon and displays the score on the screen
	void Update()
	{
		if (score < 0)
			score = 0;
		text.text = "" + score;
	}

	public static void AddPoints (int pointsToAdd){
        //if a player picks up coins then points are added to their score through this function
		score += pointsToAdd;
        
        //playerprefs is updated to the higher score
        PlayerPrefs.SetInt("CurrentScore", score);
	}

	public static void Reset(){
        //if a player dies their score is reset to 0
		score = 0;

        //playerprefs is updated to the reset score
        PlayerPrefs.SetInt("CurrentScore", score);
    }
}
