using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreScript : MonoBehaviour {
	public Text finalScore; //New variable of type Text called finalScore

	
	// Update is called once per frame
	void Update () {
		finalScore.enabled = true; //Enables the text
		GetComponent<Scoring> (); //References back to the Scoring script
		finalScore.text = ("Your final score was: " + Scoring.score); //Sets the text to display the final score.
	}
}
