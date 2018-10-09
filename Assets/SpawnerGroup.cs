﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerGroup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void KillSpawners()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
