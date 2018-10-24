using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class putter : MonoBehaviour { /* New class for the putter object */
	public static float power = 500;
	public Text text;
	public static bool shotTaken = false;
		
	// Use this for initialization
	void Start () {
		shotTaken = false;
		GetComponent<ConstantForce> ().enabled = false;   /* Makes sure the ConstantForce component is disabled to prevent
		the putter from moving beforehand */

	}
	
	// Update is called once per frame
	void Update ()
	{
		ChangePower (); //Calls function
		if (Input.GetMouseButtonUp (0)) { //if statement for when left mouse button (0) is released
			GetComponent<Rigidbody> ().AddRelativeForce (0, 0, power);
		}



	}

	void OnCollisionEnter(Collision other) /* When a collision with another object (i.e. the ball) is detected....*/
	{
		Destroy (gameObject); /*... destroy the putter*/
		GetComponent<CameraFollow> ();
		CameraFollow.putterAlive = false;



		 
	}

	void ChangePower () // New function
	{
		if (Input.GetButton ("Fire1")) { /* If the left mouse button is held down, the code below will be
			carried out.*/
			if (Input.GetAxis ("Mouse Y") < 0) { /* If the mouse is moved downwards... */
				power = power - 100; /* ...decrease the power in increments of 100 */
				if (power < 500) {
					power = 500;
				}
				//These lines of code ensure the minimum power the player can select is 500. If they try to 
				//set anything lower, it is set back to 500.

				//Logs the power each time it is changed 
			} 
			if (Input.GetAxis ("Mouse Y") > 0) { /* If the mouse is moved upwards... */
				power = power + 100; /* Increase the power in increments of 100 */
				if (power > 5000) {
					power = 5000;
				}
				//These lines of code ensure the maximum power the player can select is 5000. If they try to 
				//set anything higher, it is set back to 5000.

				//Logs the power each time it is changed 
			}
			text.enabled = true; //Enables the text (makes it visible)
			text.text = ("Power: " + power.ToString () + "/5000"); //Sets the text to say the power value out of a max of 5000.
		}

	

		else { //Otherwise (when mouse button isn't pressed down
		text.enabled = false; //Disable text
		
	}


	}

}



