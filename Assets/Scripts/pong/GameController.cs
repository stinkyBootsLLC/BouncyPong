using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
	/*Stinky Boots LLC 2017*/


	public Camera mainCamera;
	public BoxCollider2D topWall;
	public BoxCollider2D bottomWall;
	public BoxCollider2D rightWall;
	public BoxCollider2D leftWall;
	public Transform player1;
	public Transform player2;


	private GameObject startCanvas;

	void Start ()
	{
		FindStartCanvas ();
		StartCoroutine(WaitForCanvas());
	}

	void Update () 
	{
		SetWalls ();
		SetPlayers ();
	}

	void SetWalls ()
	{
		// move each wall to its edge locaction
		// for different device sizes
		topWall.size = new Vector2 (mainCamera.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f,0f)).x,1f);	
		topWall.offset = new Vector2(0f,mainCamera.ScreenToWorldPoint(new Vector3(0f,Screen.height,0f)).y + 0.5f);

		bottomWall.size = new Vector2 (mainCamera.ScreenToWorldPoint (new Vector3 (Screen.width * 2, 0f, 0f)).x, 1f);
		bottomWall.offset = new Vector2 (0f, mainCamera.ScreenToWorldPoint (new Vector3( 0f, 0f, 0f)).y - 0.5f);
	
		leftWall.size = new Vector2(1f, mainCamera.ScreenToWorldPoint(new Vector3(0f, Screen.height*2f, 0f)).y);;
		leftWall.offset = new Vector2(mainCamera.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - 0.5f, 0f);
		
		rightWall.size = new Vector2(1f, mainCamera.ScreenToWorldPoint(new Vector3(0f, Screen.height*2f, 0f)).y);
		rightWall.offset = new Vector2(mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x + 0.5f, 0f);
	}

	void SetPlayers ()
	{
		player1.transform.position = new Vector3(mainCamera.ScreenToWorldPoint(new Vector3(75f, 0f, 0f)).x, player1.transform.position.y, 0f); 
		player2.transform.position = new Vector3(mainCamera.ScreenToWorldPoint(new Vector3(Screen.width -75f, 0f, 0f)).x, player2.transform.position.y, 0f);

	}

	// this is just to check for a "start canvas" gameObject
	void FindStartCanvas ()
	{
		startCanvas = GameObject.Find("Start Canvas");

		if(!startCanvas)
		{
			Debug.LogError ("please create Start Canvas Object - EER");
		}
	}

	IEnumerator WaitForCanvas()
	{ 
		// 2 sec delay then "Get Ready" disappears
		yield return new WaitForSeconds (2f);
		startCanvas.SetActive(false);

	}

}// end
