using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour {
    public int Lives;
    private int counter;
    private Text theText;
	// Use this for initialization
	void Start () {
        theText = GetComponent<Text>();
        counter = Lives;
	}
	
	// Update is called once per frame
	void Update () {
        theText.text = "x " + counter;
	}

    public void TakeLife()
    {
        counter--;
    }
}
