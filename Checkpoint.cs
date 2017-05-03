using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

	// Use this for initialization
	public LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();
	}
	
	
	void Update () {
	// Update is called once per frame this way when the player moves into a checkpoint it'll update the checkpoint. A real time checker. 	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") {
			levelManager.currentCeckpoint = gameObject;
			Debug.Log ("Activated Checkpoint " + transform.position);
		// if player is at a new checkpoint it'll log that checkpoint as the current checkpoint  
		}
	}
}

