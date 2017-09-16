using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenery : MonoBehaviour {

	private float scrollTimer;
	private float scrollDTime;
	public float scrollSpeed;

	// Use this for initialization
	void Start () {
		scrollTimer = 0.016f;	//cap movement speed to translations per second	
	}
	
	// Update is called once per frame
	void Update () {
		scrollDTime += Time.deltaTime;

		if (scrollDTime >= scrollTimer) {
			scrollDTime = 0;

			Vector3 newPos = gameObject.transform.position;
			newPos.z -= scrollSpeed;
			gameObject.transform.position = newPos;
		}
	}
}
