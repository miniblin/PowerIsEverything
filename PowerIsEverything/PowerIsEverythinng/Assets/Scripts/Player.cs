

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : Character
{

    Rigidbody rigidbody;
    public Rigidbody bullet;
    public GameObject projectile;
    public float acceleration;
    public float maxVelocity;
    public float bulletSpeed;  
    
    //pllayer color
    float red;
    float green;
    float blue;

    //player size
    Vector3 scale;

    //screen size
    Vector3 topRight;
    Vector3 bottomLeft;
   
    void Start()
    {
        isQuitting = false;
        this.rigidbody = gameObject.GetComponent<Rigidbody>();
        health = maxHealth;
        red = 89f/256f;
        green = 238f/256f;
        blue = 103f/256f;        
        scale = transform.localScale;
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 20));
        topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 20));
    }


       
   
    void Update()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase != TouchPhase.Ended&& Input.GetTouch(i).phase != TouchPhase.Canceled) {
                    Vector3 target = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(i).position.x, Input.GetTouch(i).position.y, 20));
                    if ((Input.GetTouch(i).position.x < Screen.width / 2)){
                          
                         rigidbody.AddForce(acceleration*(new Vector3(target.x,target.y-transform.position.y,0).normalized));
                    }
                    else
                    {
                        Fire((target - transform.position).normalized);
                        //transform.LookAt(target);
                    }
              }                  
        }

        //keep player on screen
        if (transform.position.y >= topRight.y && rigidbody.velocity.y > 0)
        {
            transform.position = new Vector3(transform.position.x, topRight.y, transform.position.z);
        }
        if (transform.position.y <= bottomLeft.y && rigidbody.velocity.y < 0)
        {
            transform.position = new Vector3(transform.position.x, bottomLeft.y, transform.position.z);
        }

        if (transform.position.z < bottomLeft.z)
        {
            Kill();
        }

    }

	public void Fire(Vector3 target){
		Rigidbody bulletClone = Instantiate (bullet, (transform.position + transform.forward), Quaternion.identity);
		//bulletClone.velocity = bulletSpeed;
		bulletClone.velocity = new Vector3(0f, 0f, bulletSpeed);
	}

	/*
    //instantiate bullet, set color, set player size- decreases when firing
    public void Fire(Vector3 target)
    {
        Rigidbody bulletClone = Instantiate(bullet, (transform.position + transform.forward), Quaternion.identity);
        bulletClone.velocity =target* bulletSpeed;
        bulletClone.GetComponent<Renderer>().material.color = new Color(red / (health / maxHealth), green * (health / maxHealth), blue, 0.5f);
        bulletClone.GetComponent<AudioSource>().pitch = 1 / (health / maxHealth);
        DepleteHealth(1);
        Debug.Log("r:" + red + "g:" + green + "b:" + blue);
        GetComponent<Renderer>().material.color = new Color(red / (health / maxHealth), green * (health / maxHealth), blue, 0.5f);
        transform.localScale = (scale * health / maxHealth);
    }
  */

    public void IncrementHealth(float power)
    {
		if ((health + power) > maxHealth) {
			health = maxHealth;
		} else {
			health += power;
		}
       
        GetComponent<Renderer>().material.color = new Color(red / (health / maxHealth), green * (health / maxHealth), blue, 0.5f);
        transform.localScale = (scale * health / maxHealth);
    }


    public override void DepleteHealth(float amount)
    {
        base.DepleteHealth(amount);
        GetComponent<Renderer>().material.color = new Color(red / (health / maxHealth), green * (health / maxHealth), blue, 0.5f);
        transform.localScale = (scale * health / maxHealth);
    }
    void OnDestroy()
    {
        if (!isQuitting)
        {
            isQuitting = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}


/*
 * OLD KEYBOARD CONTROLS
 *  bool up, left, right, down,fire;
 * up = (Input.GetKey("up"));
        down = (Input.GetKey("down"));
        left = (Input.GetKey("left"));
        right = (Input.GetKey("right"));
        fire = (Input.GetKey("space"));
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
        if (up){
            if (rigidbody.velocity.y <= maxVelocity)
                {
                //rigidbody.AddForce(0, acceleration, 0);
                if (transform.position.y <= 10)
                {
                    rigidbody.AddForce(new Vector3(0, acceleration, 0));
                    goingUp = true;
                }
                else
                {
                    rigidbody.velocity = Vector3.zero;
                }
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 30);
            }

            }
        else 
        {
            if (rigidbody.velocity.y >= -maxVelocity)
            {
               
            }

        }
        if (left)
        {
            if (rigidbody.velocity.z >= -maxVelocity)
            {
                rigidbody.AddForce(0, 0, -acceleration);
            }

        }

        if (right)
        {
            if (rigidbody.velocity.z <= maxVelocity)
            {
                rigidbody.AddForce(0, 0, acceleration);
            }

        }

        if (fire)
        {
            Fire(Vector3.forward);
        }
*/
