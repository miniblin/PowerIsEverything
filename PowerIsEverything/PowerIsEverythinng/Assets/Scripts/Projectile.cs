using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public float damage;
	public float thrusterTime;
	private float thrusterTimer;

	public float accelerationValue;

	public float accelerationTime;
	private float accelerationTimer;

	// Use this for initialization
	void Start () {
		thrusterTimer = 0;
		accelerationTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (thrusterTimer < thrusterTime) {
			thrusterTimer += Time.deltaTime;
			GetComponent<Rigidbody> ().velocity = new Vector3 (0, -4, 0);
		} else {

			accelerationTimer += Time.deltaTime;

			if (accelerationTimer >= accelerationTime) {

				accelerationTimer = 0;

				GetComponent<Rigidbody> ().velocity = new Vector3 (
					0,
					0,
					GetComponent<Rigidbody> ().velocity.z + accelerationValue);
			}
			//GetComponent<Rigidbody> ().velocity.z += 1;

		}
	}

    void OnTriggerEnter(Collider col)
    {
        //all projectile colliding game objects should be tagged "Enemy" or whatever in inspector but that tag must be reflected in the below if conditional
		if (col.gameObject.tag == "Enemy") {
			col.gameObject.GetComponent<Character> ().DepleteHealth (damage);
			//add an explosion or something
			//destroy the projectile that just caused the trigger collision
			Destroy (gameObject);
		} else if (col.gameObject.tag == "CullPlane") {	// destroy the missile if it goes off the screen
			Destroy (gameObject);
		}
    }

}
