using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject currentCeckpoint;

	private PlayerController player;

	public int pointPenaltyOnDeath;



	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RespawnPlayer()
	{
		Debug.Log ("Player Respawn"); 
		
		//respawn at last checkpoint
		player.transform.position = currentCeckpoint.transform.position;
		
		//sets physics
		player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		
		//take away points for death
		ScoreManager.AddPoints (-pointPenaltyOnDeath);


	}
}
