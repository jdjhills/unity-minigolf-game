using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordPos : MonoBehaviour {
	public static Vector3 lastPosition;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<BallControlScr> ();
		if (BallControlScr.speed == 0){
			lastPosition = transform.position;

			
	}
}
}
