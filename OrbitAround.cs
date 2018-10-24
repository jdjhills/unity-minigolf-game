using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitAround : MonoBehaviour {
	public GameObject ball; /* Defines the GameObject (golf ball) as "ball" for use in this script */
	public float speed; /* Defines a floating point integer that will hold the value for the speed for the putter to rotate around the ball */

	// Update is called once per frame
	void Update () {
		OrbitBall (); /* Every frame, Update() is called which calls OrbitBall() */

	}

	void OrbitBall(){ /* Defines new function */

		if (Input.GetAxis("Mouse X")<0){ /* If the mouse is moved in a left direction (>0)... */
			transform.RotateAround (ball.transform.position, Vector3.down, speed * Time.deltaTime); /* Rotates the putter around the ball's position
		in an upwards direction at the pre-defined speed value */
		}
		if (Input.GetAxis("Mouse X")>0){ /* If the mouse is moved in a right direction (>0)... */
			transform.RotateAround (ball.transform.position, Vector3.up, speed * Time.deltaTime); /* Rotates the putter around the ball's position
		in an downwards direction at the pre-defined speed value */
		}
	}	
}

