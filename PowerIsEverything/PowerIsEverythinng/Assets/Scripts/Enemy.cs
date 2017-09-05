using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {
    public Rigidbody powerUp;
    public float powerUpSpeed;
    public GameObject explosion;
    public float acceleration;
    bool dropPowerUp;

	// Use this for initialization
	void Start () {
        dropPowerUp = true;
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
            if (dropPowerUp)
            {
                Rigidbody powerUpClone = Instantiate(powerUp, (transform.position), Quaternion.identity);
                powerUpClone.velocity = -transform.forward * powerUpSpeed;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Collider col = collision.collider;
        //all projectile colliding game objects should be tagged "Enemy" or whatever in inspector but that tag must be reflected in the below if conditional
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Character>().DepleteHealth(health);
            //add an explosion or something
            //destroy the projectile that just caused the trigger collision
            dropPowerUp = false;
            Destroy(gameObject);
        }
    }
}
