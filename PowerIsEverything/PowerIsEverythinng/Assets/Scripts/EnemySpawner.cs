﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public Rigidbody enemy;
    int count;
    Vector3 edgeVector;
    // Use this for initialization
    void Start () {
        
        edgeVector =Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, 20));

    }
	
	// Update is called once per frame
	void Update () {
        if (count > 100) {
            Debug.Log(edgeVector);

            Rigidbody enemyclone = Instantiate(enemy, new Vector3(transform.position.x, Random.Range(-8.0f, 8.0f), edgeVector.z+2f), Quaternion.identity);
            //enemyclone.velocity = -transform.forward*5;
            count = 0;

            }
        count++;
        

    }
}
