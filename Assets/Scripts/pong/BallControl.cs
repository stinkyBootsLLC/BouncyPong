using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallControl : MonoBehaviour {
/*Stinky Boots LLC 2017*/

	public float ballSpeed = 50f;

	private float randomNumber;
	private Rigidbody2D ballRigidBody2D;
	private AudioSource ballAudio;

	void Start () 
	{
		 ballRigidBody2D = gameObject.GetComponent<Rigidbody2D>();
		
		 ballAudio = gameObject.GetComponent<AudioSource>();

		 StartCoroutine(WaitForBall());
	}

	void Update ()
	{
		// store the balls x velocity into a float variable
		// to check the value and do the below formula
		float xVel = ballRigidBody2D.velocity.x;

		// store the rigidbody2d in temp variable to adjust it
		Vector2 xVel2 = ballRigidBody2D.velocity; 


		// this is to fix a bug, when the ball hits the 
		// top of paddle and goes reallys slow
		if (xVel < 10 && xVel > -10 && xVel != 0)
		{
			if (xVel > 0)
			{	
				// adds xVel2 to ballRigidBody2D.velocity.x
				ballRigidBody2D.AddForce(Vector2.right + xVel2);
			}
			else
			{
				ballRigidBody2D.AddForce(Vector2.left + xVel2); 
			}

			//Debug.Log ("fix applied " + ballRigidBody2D.velocity.x);

		}

	}

	void ResetBall ()
	{
		// stop velocity
		// reset transform position

		ballRigidBody2D.velocity = new Vector2(0,0); 
		ballRigidBody2D.transform.position = new Vector2 (0, 0); 

		StartCoroutine(WaitForResetBall());

	}

	void MoveBall ()
	{
		//Returns a random float number between and min [inclusive] 
		//and max [inclusive] (Read Only)
		randomNumber = Random.Range(0.0f, 2.0f);	

		if (randomNumber <= 0.5)
		{
			ballRigidBody2D.AddForce (new Vector2 (ballSpeed, 10));
			//Shoot ball to the right
		}
		else
		{
			ballRigidBody2D.AddForce (new Vector2 (-ballSpeed, -10));
			//Shoot ball to the left
		}

	}


	// will only be called once on collision
	void OnCollisionEnter2D (Collision2D collision)
	{
		// checks if hit player collider
		if (collision.collider.tag == "Player") 
		{       
			// this is so the ball doesnt take the 
			// same path everytime paddle hits it
			// so its not predictable

			float velY = ballRigidBody2D.velocity.y;       
			ballRigidBody2D.velocity = new Vector2(ballRigidBody2D.velocity.x , velY/2 + 
			collision.collider.GetComponent<Rigidbody2D>().velocity.y/3);

			// audio source component
			ballAudio.pitch = Random.Range(0.8f, 1.2f);
			ballAudio.Play();

			// particle system
			ParticleSystem ps = GetComponent<ParticleSystem>();
        	var em = ps.emission; // store in temp variable
         	em.enabled = true;    // emmission is enabled
         	ps.Play();           // playing the particle system

		}

	}	

	void OnTriggerEnter2D (Collider2D collider)
	{
		// the ball collided with a side wall 
		// and triggered
		if(collider.tag == "ScoreWall")
		{
			ResetBall ();
		}

	}


	    /*DELAY TIMES*/
	IEnumerator WaitForBall()
	{ 
		// 3 sec delay only in the beginning of game
		yield return new WaitForSeconds (3f);
		MoveBall (); 

	}

	IEnumerator WaitForResetBall()
	{ 
		// 1 sec delay after resetting the ball
		yield return new WaitForSeconds (1f);
		MoveBall (); 

	}
		/*DELAY TIMES*/

}//end
