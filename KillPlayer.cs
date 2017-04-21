using System.Collections;
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
        if (livesSystem.currentLives() == 0)
        {
            Debug.Log('0');
            deathMenu.ToggleMenu();
            control.onDeath();
            livesSystem.TakeLife();
        }
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") {
            livesSystem.TakeLife();
            levelManager.RespawnPlayer();
            
		}
	}
}
