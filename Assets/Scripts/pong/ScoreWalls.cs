using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreWalls : MonoBehaviour {
	/*Stinky Boots LLC 2017*/

	private AudioSource scoreAudio;


	void Start () 
	{
		scoreAudio = gameObject.GetComponent<AudioSource>();
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		if(collider.tag == "Ball")
		{
			ScoreManager.Score(this.gameObject);

			//play sound from gameObject Component
			scoreAudio.Play();

		}
	}
}//end
