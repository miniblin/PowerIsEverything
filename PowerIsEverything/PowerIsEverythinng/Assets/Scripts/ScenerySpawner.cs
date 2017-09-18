using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenerySpawner : MonoBehaviour {

	public float buildingTimer;
	private float buildingDeltaTime;

	public Transform building1;
	public Transform building2;
	public Transform building3;
	public Transform building4;

	//public Transform buildingCluster;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		buildingDeltaTime += Time.deltaTime;
		if (buildingDeltaTime >= buildingTimer) {
			buildingDeltaTime = 0;


			switch (Random.Range(1, 4)) {
			case 1:
				Instantiate (building1);
				break;
			case 2:
				Instantiate (building2);
				break;
			case 3:
				Instantiate (building3);
				break;
			case 4:
				Instantiate (building4);
				break;
			default:
				break;
			}
		}
	}
}
