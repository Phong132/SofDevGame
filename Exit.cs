using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Zone");
            playerInZone = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Out");
        if (other.name == "Player")
        {
            playerInZone = false;
        }
    }

}
