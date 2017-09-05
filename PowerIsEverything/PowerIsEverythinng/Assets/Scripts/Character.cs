using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    public float maxHealth;
    protected float health;

	// Use this for iSnitialization
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void DepleteHealth(float amount)
    {
        if (health - amount > 0)
        {
            health -= amount;
        }
        else
        {
            health = 0;
            Kill();
        }
    }


    public virtual void Kill()
    {
        Destroy(gameObject);
    }

    public static bool isQuitting = false;
    void OnApplicationQuit()
    {
        isQuitting = true;
    }
}
