using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallout : MonoBehaviour {
	// Use this for initialization
	Vector2 checkpoint;
	void Start () {
		checkpoint = new Vector2 (0, 5);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -10) {
			transform.position = checkpoint;
		}
	}
}
