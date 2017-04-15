using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;// new sceneManger requirement

public class ScoreManager : MonoBehaviour 
{
	/*Stinky Boots LLC 2017*/

	public GUISkin _guiSkin;
	public int maxScore = 5;

	private static int _player1Score = 0; 
	private static int _player2Score = 0;

	void Update ()
	{
		EndGame();
	
	}

	public static void Score(GameObject wall) 
	{ 
		if (wall.name == "RightWall")
		{
		 	_player1Score++; 
		}
		else if(wall.name == "LeftWall")
		{
			_player2Score++;
		} 

	}



	public void OnGUI() 
	{ 
		GUI.skin = _guiSkin; 
		GUI.Label(new Rect(Screen.width / 2 - 150-12, 25, 100, 100), "" + _player1Score); 
		GUI.Label(new Rect(Screen.width / 2 + 165-12, 20, 100, 100), "" + _player2Score); 

	}

	void EndGame ()
	{
		if (_player1Score == maxScore || _player2Score == maxScore)
		{
			_player1Score = 0; 
			_player2Score = 0;

			// you can pass an interger or a string
			UnityEngine.SceneManagement.SceneManager.LoadScene ("GameOver");
		}

	}

}//end

