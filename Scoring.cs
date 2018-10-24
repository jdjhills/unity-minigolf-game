using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //This ensures I'll be able to change scenes.
using UnityEngine.UI; //Allows me to control UI elements from the script

public class Scoring : MonoBehaviour {
	public Rigidbody rb; //New rigidbody called rb (this references the ball)
	public GameObject ball; //New GameObject for the ball
	public static float speed; //Defines a global static integer that holds the speed
	public static float score = 0; //Defines a global static integer that hold the score and sets it to 0.
	public bool inHole = false; //Defines a new boolean and sets it to false
	public bool hasMoved; //New boolean variable
	public Text outcome; //Defines text for the outcomeText object
	public Text scoreText; //New Text type variable for the score text

	void Awake() { //Awake() is called as the script is being loaded
		hasMoved = false; //inititally sets "hasMoved" to false.

	}

	void Start () {
		GetComponent<putter> (); //Reference to the putter script
		putter.shotTaken = false; //Pulls the shotTaken boolean from the putter script and sets it to false
		outcome.enabled = false; //Disables the outcome text so no text shows up yet
	}

	// Update is called once per frame
	void Update () {
		speed = rb.velocity.magnitude; //sets the speed to the magnitude of the ball's velocity
		scoreText.enabled = true; //Enables the scoreText
		scoreText.text = ("Your current score is: " + score); //Sets the scoreText to display the
		Debug.Log(score); //Writes score to log every frame
		if (speed > 1) { //If the speed goes above 1, hasMoved is set to true.
			hasMoved = true; //Now, the script knows if the ball has moved because it's speed
			//has changed.
		}

		if ((hasMoved==true) && (speed == 0)) { //If the ball has moved and its speed goes back down to 0, 
			//it cannot be in the hole (the ball would still be moving a bit if it went in hole)
			outcome.enabled = true; //Enables outcomeText
			Scene scene = SceneManager.GetActiveScene(); //Gets the active scene
			if (scene.name != "play-woodland-hole4") { //Checks to see if the active scene has a name NOT equal to "play-woodland-hole4"
				outcome.text = ("Unlucky. Loading next hole..."); //Sets the value of the text
			} 
			else {
				outcome.text = ("Unlucky. Game over."); //If the scene is play-woodland-hole4, displays this text instead
			}
			NextHole (); //Calls the NextHole() function below

	
	}
	}
		

			
	void OnTriggerEnter(Collider other) //New function for when a collision happens
	{
		if (other.name == "holeBottom") { //If the name of the object is holeBottom, the ball is in the hole.
			inHole = true; //If the ball is in the hole, inHole is set to true.
			if ((inHole == true)){ //If inHole is true, the ball is in the hole
				score = score + 10; //So the score is increased by 10 points
				outcome.enabled = true; //And the outcomeText is enabled
				Scene scene = SceneManager.GetActiveScene(); //Gets the active scene
				if (scene.name != "play-woodland-hole4") { //Checks to see if the active scene has a name NOT equal to "play-woodland-hole4"
					outcome.text = ("Hole in one! Loading next hole..."); //Sets the value of the text
				}
				else { //Otherwise, the scene name is play-woodland-hole4 
					outcome.text = ("Hole in one! Game over."); // Sets the outcomeText value
				NextHole(); //Calls the NextHole() function below
			}

		}
	}
	}
		

	void NextHole () //New function for when the next hole or scene needs to be loaded
		{
		Scene scene = SceneManager.GetActiveScene(); //Retrieves value of the current scene and saves it to variable scene.

		if (scene.name == "play-woodland-hole1") { //Checks to see if the active scene has a name equal to "play-woodland-hole1"
			GetComponent<CameraFollow> (); //Used to get a variable from the CameraFollow script
			CameraFollow.putterAlive = true; //Changes the putterAlive boolean to true (to make sure camera works on next hole when putter is enabled)
			SceneManager.LoadScene ("play-woodland-hole2"); //Loads the scene called "play-woodland-hole2"
		}
		if (scene.name == "play-woodland-hole2") { //Checks to see if the active scene has a name equal to "play-woodland-hole2"
			GetComponent<CameraFollow> ();//Used to get a variable from the CameraFollow script
			CameraFollow.putterAlive = true;//Changes the putterAlive boolean to true (to make sure camera works on next hole when putter is enabled)
			SceneManager.LoadScene ("play-woodland-hole3");//Loads the scene called "play-woodland-hole3"
		}
		if (scene.name == "play-woodland-hole3") { //Checks to see if the active scene has a name equal to "play-woodland-hole3"
			GetComponent<CameraFollow> ();//Used to get a variable from the CameraFollow script
			CameraFollow.putterAlive = true;//Changes the putterAlive boolean to true (to make sure camera works on next hole when putter is enabled)
			SceneManager.LoadScene ("play-woodland-hole4");//Loads the scene called "play-woodland-hole4"
		}
		if (scene.name == "play-woodland-hole4") {//Checks to see if the active scene has a name equal to "play-woodland-hole4"
			GetComponent<CameraFollow> ();//Used to get a variable from the CameraFollow script
			CameraFollow.putterAlive = true;//Changes the putterAlive boolean to true (to make sure camera works on next hole when putter is enabled)
			SceneManager.LoadScene ("play-woodland-finish");//Loads the scene called "play-woodland-finish"
		}
	}



}



