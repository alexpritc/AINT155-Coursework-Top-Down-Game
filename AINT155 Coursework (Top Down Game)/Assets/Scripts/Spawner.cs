﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    // Declaring variables.
    public GameObject toBeSpawned;



	// Use this for initialization.
	void Start () {

        toBeSpawned.transform.position = gameObject.transform.position;
	}
	
}
