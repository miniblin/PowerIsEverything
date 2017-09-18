using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCuller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision){
		//any object that collides with this gets destroyed
		Destroy(collision.gameObject);
	}

}
