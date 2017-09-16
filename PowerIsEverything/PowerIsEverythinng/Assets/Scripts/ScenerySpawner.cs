using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenerySpawner : MonoBehaviour {

	public float buildingTimer;
	private float buildingDeltaTime;

	public Rigidbody building1;
	public Rigidbody building2;
	public Rigidbody building3;
	public Rigidbody building4;

	public Transform buildingCluster;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		buildingDeltaTime += Time.deltaTime;
		if (buildingDeltaTime >= buildingTimer) {
			buildingDeltaTime = 0;
			//int number = Random.Range (1, 4);
			Instantiate(buildingCluster);
		}
	}
}
