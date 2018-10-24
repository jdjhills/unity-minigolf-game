using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControlScr : MonoBehaviour {
	public Transform putterObj; //Defines a Transform for the putter
	public GameObject ball; //Defines a new GameObject called ball
	public Vector3 newCoords; //New Vector3 called newCoords
	public Vector3 oldCoords; //New Vector3 called oldCoords
	public Vector3 distanceBallPutter; //New Vector3 called distanceBallPutter
	public Rigidbody ballrb; //New Rigidbody for ball
	public static float speed; //New float integer which will hold speed of ball
	public float numCreated; //


	// Use this for initialization
	void Start () {
		oldCoords = putterObj.position;
		distanceBallPutter = transform.position - oldCoords;
	}

	// Update is called once per frame
	void Update () {
		Rigidbody ballrb = GetComponent<Rigidbody> ();
		speed = ballrb.velocity.magnitude;
		InstantiateNewPutter ();
		Debug.Log (speed);
		Debug.Log (CameraFollow.putterAlive);


		}
	void InstantiateNewPutter (){
		GetComponent<CameraFollow> ();
		GetComponent<putter> ();
		if (speed == 0 && (!CameraFollow.putterAlive) && (numCreated <12))
			//if (Input.GetKeyDown ("space"))
			{
				GetComponent<putter> ();
				newCoords = ball.transform.position - distanceBallPutter;
				//GetComponent<Rigidbody> ().velocity = new Vector3 (0,0,0); //sets vel to o
				Instantiate(putterObj, newCoords, putterObj.rotation);
				GetComponent<CameraFollow> ();
				CameraFollow.putterAlive = true;
				numCreated = numCreated + 1;

		}
	}
}
