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

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		buildingDeltaTime += Time.deltaTime;
		if (buildingDeltaTime >= buildingTimer) {
			buildingDeltaTime = 0;
			int number = Random.Range (1, 4);

			if (number == 1) {
				Rigidbody newBuilding = Instantiate (building1);
				newBuilding.velocity = new Vector3 (0f, 0f, -100f);
			} else if (number == 2) {
				Rigidbody newBuilding = Instantiate (building2);
				newBuilding.velocity = new Vector3 (0f, 0f, -100f);
			} else if (number == 3) {
				Rigidbody newBuilding = Instantiate (building3);
				newBuilding.velocity = new Vector3 (0f, 0f, -100f);
			} else if (number == 4) {
				Rigidbody newBuilding = Instantiate (building4);
				newBuilding.velocity = new Vector3 (0f, 0f, -100f);
			}
			//building.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 100f);
		}
	}
}
