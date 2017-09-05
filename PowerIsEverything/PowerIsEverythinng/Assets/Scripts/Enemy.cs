using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {
    public Rigidbody powerUp;
    public float powerUpSpeed;
    public GameObject explosion;
    public float acceleration;

	// Use this for initialization
	void Start () {
        health = maxHealth;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
         rigidbody.AddForce(0, 0, -rigidbody.mass*acceleration);
        
    }
	
	// Update is called once per frame
	void Update () {

		
	}

    public override void DepleteHealth(float amount)
    {
        base.DepleteHealth(amount);
        if (health > 0)
        {
            transform.localScale = (Vector3.one / (health / maxHealth));
        }
    }
   

    void OnDestroy()
    {
        if (!isQuitting)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Rigidbody powerUpClone = Instantiate(powerUp, (transform.position), Quaternion.identity);
            powerUpClone.velocity = -transform.forward * powerUpSpeed;
        }
    }
}
