using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highScoreScript : MonoBehaviour
{

    public GameObject score;
    public GameObject name;
    public GameObject rank;

    public void setScore(string name, string score, string rank)
    {
        this.rank.GetComponent<Text>().text = rank;
        this.name.GetComponent<Text>().text = name;
        this.score.GetComponent<Text>().text = score;
    }
}
