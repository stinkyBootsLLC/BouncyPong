using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	/*Stinky Boots LLC 2017*/

	// https://www.youtube.com/playlist?list=PLPV2KyIb3jR4_IYZY2V0G3IUYcx1zZkJe
	// How to make a 2D Game - Unity 4.3 Course  - Brackeys

	public float speed = 10f;  // speed for Y axis
	public KeyCode moveUp;   // adjustable in inspector, assign a key
	public KeyCode moveDown;  // adjustable in inspector, assign a key

	private Rigidbody2D playerRigidBody2d;

	void Start () 
	{
		playerRigidBody2d = gameObject.GetComponent<Rigidbody2D>();
	}
	

	void Update () 
	{
		if(Input.GetKey(moveUp))
		{
			playerRigidBody2d.velocity = new Vector2(0f, speed);
		}
		else if (Input.GetKey(moveDown))
		{
			playerRigidBody2d.velocity = new Vector2(0f, -speed);
		}
		else
		{
			playerRigidBody2d.velocity = new Vector2(0f, 0f);
		}
		
	}
}//end
