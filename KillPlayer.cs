using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

	public LevelManager levelManager;
    private LifeManager lifesSystem;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();
        lifesSystem = FindObjectOfType<LifeManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") {
            lifesSystem.TakeLife();
			levelManager.RespawnPlayer();
		}
	}
}
