using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public GameObject player; /*Defines variable which stores a reference to the player game object */
	public Transform ball; /* Defines a reference to the Transform of a GameObject (the ball), which stores its 
	position, rotation and scale */
	public float speed; /* Defines integer which stores the speed as a floating-point integer */
	public static bool putterAlive = true; /* Global variable which stores whether the putter is "alive" or not & sets it to true */

	public static Vector3 offset;      /* Private variable to store the offset distance between the player and camera */

	// Use this for initialization
	void Start () 
	{
		offset = transform.position - player.transform.position;
		/*Calculate and store the offset value by getting the distance between the player's position and camera's position.*/
	}
	void alive () {
		putterAlive = true;
	}

	void Update () {
		if (Input.GetAxis ("Mouse ScrollWheel") > 0) { //If the mouse scrollwheel is moved upwards, reduce the field of view (zoom in) 
			GetComponent<Camera> ().fieldOfView -= 1;
		}
		if (Input.GetAxis ("Mouse ScrollWheel") < 0) { //If the mouse scrollwheel is moved downwards, increase the field of view (zoom out)
			GetComponent<Camera> ().fieldOfView += 1;
		}
						
		if (putterAlive == true) { /* If the putter is alive...*/
			RotateAround (); /*...Calll the RotateAround() function below */

		}

		if (putterAlive == false) { /* If the putter is not alive...*/
			transform.position = player.transform.position + offset; 
			/*Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.*/
			transform.LookAt (ball); /* Make camera always look at the ball when the putter is non existant */
			}
		}

	void RotateAround(){
		if (Input.GetAxis("Mouse X")<0){ /* If the mouse is moved in a left direction (>0)... */
			transform.RotateAround (player.transform.position, Vector3.down, speed * Time.deltaTime); /* Rotates the putter around the ball's position
		in an upwards direction at the pre-defined speed value */
		}
		if (Input.GetAxis("Mouse X")>0){ /* If the mouse is moved in a right direction (>0)... */
			transform.RotateAround (player.transform.position, Vector3.up, speed * Time.deltaTime); /* Rotates the putter around the ball's position
		in an downwards direction at the pre-defined speed value */
		}

	}	

}