﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

	public void LoadScene(string name)
    {
        Application.LoadLevel(name);
    }
}
