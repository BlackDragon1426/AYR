using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{
	Vector3 oldPosition;

	Vector3 constantForce;

	public Vector3 momentum;

	public float speed;
	Vector3 applyedMotion;


	bool grounded = false;

	void FixedUpdate()
	{
		Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); 
		Vector3 velocity = new Vector3(0,0,0);
		velocity = oldPosition - transform.position;
		oldPosition = transform.position;
		Debug.Log("Current Velocity EveryFixedFrame " + velocity + " Actual speed " + velocity.sqrMagnitude / Time.deltaTime);



		if (input.sqrMagnitude > 1) input.Normalize();

		transform.Translate(input * speed * Time.deltaTime);
		transform.position += momentum;

	}
}
