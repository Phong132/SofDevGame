using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

	public int pointsToAdd;

	void OnTriggerEnter2D ( Collider2D other)
	{
		if(other.GetComponent<PlayerController>() == null)
			return;

		ScoreManager.AddPoints (pointsToAdd);
		// will add points to the score manager 

		Destroy (gameObject);
		//Once the player collects the coin, it'll dissappear 
	}
}
