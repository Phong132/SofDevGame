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

    private List<gameScores> allScores = new List<gameScores>();

    public GameObject scorePrefab;
    public Transform scoreParent;
    public int topTen;
    public InputField entername;
    public GameObject nameDialog;

	// Use this for initialization
	void Start ()
    {
        connectString = "URI=file:" + Application.dataPath + "/highscore.sqlite";
        if (PlayerPrefs.GetInt("CurrentScore") == 0)
        {
            nameDialog.SetActive(!nameDialog.activeSelf);
        }
        getScores();
        showScores();
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void enterName()
    {
        if (entername.text != string.Empty)
        {
            int score = PlayerPrefs.GetInt("CurrentScore");
            putScores(entername.text, score);
            entername.text = string.Empty;
            nameDialog.SetActive(!nameDialog.activeSelf);
            showScores();
        }
    }

    private void putScores(string name, int score)
    {
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
        allScores.Sort();
    }

    private void deleteScore(int id)
    {
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
        getScores();
      
        foreach(GameObject gameScores in GameObject.FindGameObjectsWithTag("score"))
        {
            Destroy(gameScores);
        }

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
