using UnityEngine;
using System.Collections;

public class PlayerMotionOld : MonoBehaviour
{
	Rigidbody PlayerRigidBody;

	public Vector3 playerMotionDirection = new Vector3 (0,0,0);
	Vector3 relativeMotionToWorld;
	public float targetJumpHeight = 1f;
	bool grounded = false;

	void Start()
	{
		PlayerRigidBody = GetComponent<Rigidbody>();
	}

	void FixedUpdate ()
	{

		relativeMotionToWorld = transform.TransformDirection(playerMotionDirection);

		Ray SpeedCollisionProtection = new Ray (transform.position, relativeMotionToWorld);
		RaycastHit[] hits = Physics.RaycastAll(SpeedCollisionProtection, 0.5f + (playerMotionDirection * Time.deltaTime).sqrMagnitude);
		Debug.DrawRay(SpeedCollisionProtection.origin, SpeedCollisionProtection.direction * ((playerMotionDirection * Time.deltaTime).sqrMagnitude + 0.5f), Color.green);

		float nearest = Mathf.Infinity;
		int closestRay = -1;

		for (int i = 0; i < hits.Length; i++)
		{
			if (!hits[i].collider.isTrigger && hits[i].distance < nearest)
			{
				nearest = hits[i].distance;
				closestRay = i;
			}	
		}

		if (closestRay > -1)
		{
			transform.position = hits[closestRay].point - (playerMotionDirection.normalized * 0.5f);
		}
		else PlayerRigidBody.MovePosition(PlayerRigidBody.position + playerMotionDirection * Time.deltaTime);

		closestRay = -1;

		if (Input.GetKeyDown(KeyCode.Z) && grounded) {
			jump ();
			grounded = false;
		}
		if (Input.GetKey(KeyCode.X))
			grounded = true;
	}

	void jump()
	{
		GetComponent<Rigidbody>().velocity += transform.TransformDirection (0f, Mathf.Sqrt(2f * targetJumpHeight * Physics.gravity.magnitude), 0f);
	}
}