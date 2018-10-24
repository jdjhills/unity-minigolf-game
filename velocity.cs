using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour
{
	

	float maxSpeed = 1.0f; // units/sec
	void FixedUpdate() {
		Rigidbody rb = GetComponent<Rigidbody>();
		Vector3 vel = rb.velocity;
		if (vel.magnitude > maxSpeed) {
			rb.velocity = vel.normalized * maxSpeed;
		}
	}
}