using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagerScript : MonoBehaviour {
	
	public void ButtonManager(string buttonClick) // Function called when button is clicked

	{
		GetComponent<Scoring> (); //Reference to Scoring script
		Scoring.score = 0;//Sets score to 0
		SceneManager.LoadScene (buttonClick); //Loads the scene stored in the buttonClick variable
	}


	public void QuitGame() /* Function called when button pressed */
	{
		Application.Quit ();
	}
}
