using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
    public float power;
    // Use this for initialization
    public float velocity;
	void Start () {
        if(velocity>0)
         GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -velocity);
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter(Collider col)
    {
        //all projectile colliding game objects should be tagged "Enemy" or whatever in inspector but that tag must be reflected in the below if conditional
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Player>().IncrementHealth(power);
            //add an explosion or something
            //destroy the projectile that just caused the trigger collision
            Destroy(gameObject);
        }
    }
}
