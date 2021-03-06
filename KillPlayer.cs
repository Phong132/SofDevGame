﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillPlayer : MonoBehaviour {

	public LevelManager levelManager;
    private LifeManager livesSystem;
    public DeathMenu deathMenu;
    public PlayerController control;

    // Use this for initialization
    void Start () {
		levelManager = FindObjectOfType<LevelManager> ();
        livesSystem = FindObjectOfType<LifeManager>();
	}
	
	// Update is called once per frame
	void Update () {
        
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") {
            livesSystem.TakeLife();
	// if the player triggers the hit box of the spike it'll take away a life from the player 
            levelManager.RespawnPlayer();
 	// after they die it'll respawn player into the last checkpoint touched 
            if (livesSystem.currentLives() == 0)
            {
                Debug.Log('0');
                deathMenu.ToggleMenu();
                control.Done();
		// If lives go to zero the death menu will pop up
            }

        }

	}
}
