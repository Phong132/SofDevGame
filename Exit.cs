using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is used by the exit doors in the game to go to the next level.
public class Exit : MonoBehaviour {
    private bool playerInZone;
    public string Level;
	// Use this for initialization
	void Start () {
        playerInZone = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.S) && playerInZone)
        {
            Debug.Log("S");
            Application.LoadLevel(Level);

        }
	}

	
	//change Bool if your are in the door
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Zone");
            playerInZone = true;
        }
    }
//change Bool if your are out of the door
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Out");
        if (other.name == "Player")
        {
            playerInZone = false;
        }
    }

}
