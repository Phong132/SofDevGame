using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.UI;

public class highscoremanager : MonoBehaviour {
    //special thanks to inScope Studios for all the help with creating this database
    private string connectString;
	//list of game scores
    private List<gameScores> allScores = new List<gameScores>();

    public GameObject scorePrefab;
    public Transform scoreParent;
    public int topTen;
    public InputField entername;
    public GameObject nameDialog;

	// Use this for initialization
	void Start ()
    {
		//puts the score into the sqlite database
        connectString = "URI=file:" + Application.dataPath + "/highscore.sqlite";
		//creates the database if a database has not been created yet
        makeTable();
		//prevents the insert name box from appearing if there's no score to insert
        if (PlayerPrefs.GetInt("CurrentScore") == 0)
        {
            nameDialog.SetActive(!nameDialog.activeSelf);
        }
		//get the scores from the database and show them to the player
        getScores();
        showScores();
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    private void makeTable()
    {
	    //uses the connection to the SQLite database to create a table to store the scores the first time the game is booted up
        using (IDbConnection datab = new SqliteConnection(connectString))
        {
            datab.Open();
            using (IDbCommand databcmd = datab.CreateCommand())
            {
                string squery = String.Format("CREATE TABLE if not exists scores (Player INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, Name TEXT NOT NULL, Score INTEGER NOT NULL)");
               //individual scores are added later and released with the final version of the game, we just need the table made for now
                databcmd.CommandText = squery;
                databcmd.ExecuteScalar();
                datab.Close();
            }
        }
    }

    public void enterName()
    {
	    //lets you put a name and score into the database
        if (entername.text != string.Empty)
        {
            int score = PlayerPrefs.GetInt("CurrentScore");
            putScores(entername.text, score);
		//the following deactivates the input field, makes the input name box disappear, and shows the updated score list
            entername.text = string.Empty;
            nameDialog.SetActive(!nameDialog.activeSelf);
            showScores();
        }
    }

    private void putScores(string name, int score)
    {
	    //puts a score into the database
        using (IDbConnection datab = new SqliteConnection(connectString))
        {
            datab.Open();
            using (IDbCommand databcmd = datab.CreateCommand())
            {
                string squery = String.Format("INSERT INTO scores(Name, Score) VALUES(\"{0}\",\"{1}\")",name,score);
                databcmd.CommandText = squery;
                databcmd.ExecuteScalar();
                datab.Close();
            }
        }
    }

    private void getScores()
    {
	    //gets scores from the database and puts them into the allScores list
        allScores.Clear();
        using (IDbConnection datab = new SqliteConnection(connectString))
        {
            datab.Open();
            using (IDbCommand databcmd = datab.CreateCommand())
            {
                string squery = "SELECT * FROM scores";
                databcmd.CommandText = squery;
                using (IDataReader read = databcmd.ExecuteReader())
                {
                    while(read.Read())
                    {
                        allScores.Add(new gameScores(read.GetInt32(0),read.GetInt32(2),read.GetString(1)));
                    }
                    datab.Close();
                    read.Close();
                }
            }
        }
	    //the following sorts the scores like we want them
        allScores.Sort();
    }

    private void deleteScore(int id)
    {
	    //this lets us take scores out of the database, if need be
        using (IDbConnection datab = new SqliteConnection(connectString))
        {
            datab.Open();
            using (IDbCommand databcmd = datab.CreateCommand())
            {
                string squery = String.Format("DELETE FROM scores WHERE Player = \"{0}\"",id);
                databcmd.CommandText = squery;
                databcmd.ExecuteScalar();
                datab.Close();
            }
        }
    }
    
    private void showScores()
    {
	    //displays the scores like we want them. First we get the scores
        getScores();
      //now we get rid of any gameScore object which is already on screen
        foreach(GameObject gameScores in GameObject.FindGameObjectsWithTag("score"))
        {
            Destroy(gameScores);
        }
	//now for our top ten  scores, we insert a scorePrefab which shows the score, its name, and its rank
        for (int i=0; i < topTen; i++)
        {
            if (i <= allScores.Count - 1)
            {
                GameObject tmp = Instantiate(scorePrefab);
                gameScores tmpScore = allScores[i];
                tmp.GetComponent<highScoreScript>().setScore(tmpScore.name, tmpScore.score.ToString(), "#" + (i + 1).ToString());
                tmp.transform.SetParent(scoreParent);
            }
        }
    } 
}
