using UnityEngine;
using System.Collections;

public class PaddleScript : MonoBehaviour {
	/*Stinky Boots LLC 2017*/
public bool autoPlay = false;
public float autoPaddleSpeed = 0f;

private BallControl ball;


	
	void Start () 
	{
		ball = GameObject.FindObjectOfType<BallControl>();
	}

	void Update () 
	{
		if (!autoPlay)//if NOT autoPlay
		{
			// normal key board operation
			MoveWithKeys();
		}
		else
		{
			AutoPlay();
		}	
	
	}
	
	void AutoPlay ()
	{
		Vector3 move = Vector3.zero;

		// how fast the paddle moves in auto mode
		//float paddleSpeed = 4.0f; 

		float d = ball.transform.position.y - transform.position.y;
	    if(d > 0)
		    {
			move.y = autoPaddleSpeed * Mathf.Min(d, 1.0f);    
		    }
	    if(d < 0)
		    {
			move.y = -(autoPaddleSpeed * Mathf.Min(-d, 1.0f));
		    }
	    transform.position += move * Time.deltaTime;
	}
	
	void MoveWithKeys () 
	{
		PaddleLimits();

	}

	void PaddleLimits ()
	{
		float limitSpeed = 1.0f;
        float minY = -5.0f;
        float maxY = 5.0f;

		float movement = Input.GetAxis("Vertical") * Time.deltaTime * limitSpeed;
        transform.Translate(new Vector3(0, movement, 0));
 
        Vector3 paddlePos = transform.position;
        paddlePos.y = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = paddlePos;
	}
}
