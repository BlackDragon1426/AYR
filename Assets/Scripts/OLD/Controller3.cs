﻿using UnityEngine;
using System.Collections;

public class Controller3 : MonoBehaviour
{
	public float speed;
    private float jumpPower = 5f;
	private float yv;

	float nearest;
	float squatingDistance;
	int closestRay = 0;
                                              
	bool _grounded;
	public bool grounded
	{
		get
		{
			return _grounded;
		}
		set
		{
			_grounded = value;

			if(_grounded == true)
			{
//				rigidbody.AddForce(-Physics.gravity * (1 + squatingDistance));
				GetComponent<Rigidbody>().useGravity = false;
//				rigidbody.velocity -= rigidbody.velocity * Time.deltaTime * 10;
			}
			else if(_grounded == false)
			{
				GetComponent<Rigidbody>().AddForce(GetComponent<Rigidbody>().velocity.x,0,GetComponent<Rigidbody>().velocity.z, ForceMode.VelocityChange);
				GetComponent<Rigidbody>().useGravity = true;
			}
		}
	}
	private Vector2 input;
	Vector3 desiredMove = new Vector3(0,0,0);

	public Speed speedScript;

//	IEnumerator GroundCheck()
//	{
//		while(true)
//		{
//			yield return null;
//			
//		}
//	}

    void Awake ()
	{
//		StartCoroutine (GroundCheck());

		speedScript = GetComponent<Speed>();
	}
	
	public void FixedUpdate ()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		bool jump = Input.GetButton("Jump");

		input = new Vector2( h, v );

		Ray ray = new Ray(transform.position + new Vector3(0,1,0), -transform.up);

		RaycastHit[] hits = Physics.RaycastAll(ray, 1);

		nearest = Mathf.Infinity;

		GetComponent<Rigidbody>().useGravity = true;
		grounded = false;
	
		if (grounded || GetComponent<Rigidbody>().velocity.y < 0.1f)
		{
			for (int i = 0; i < hits.Length; i++)
			{
				if (!hits[i].collider.isTrigger && hits[i].distance < nearest)
				{
					nearest = hits[i].distance;

					if(!grounded)
						grounded = true;

					closestRay = i;
				}

			}
		}

		squatingDistance = 1 - nearest;

		if(squatingDistance < 0)
			squatingDistance = 0;

		Debug.DrawRay(ray.origin, ray.direction * 1, grounded ? Color.green : Color.red );

		if (input.sqrMagnitude > 1) input.Normalize();

//		yv = rigidbody.velocity.y;

		if (grounded && jump)
		{
			yv = jumpPower;
		}
		else 
			yv = 0;

		desiredMove = transform.forward * input.y * speed + transform.right * input.x * speed + transform.up * yv;

		Vector3 targetMovement = GetComponent<Rigidbody>().velocity + desiredMove;
		GetComponent<Rigidbody>().velocity = targetMovement;
		targetMovement -= desiredMove;
		transform.Translate(0,squatingDistance * 3 * Time.deltaTime,0);
//		rigidbody.velocity -= rigidbody.velocity * 10 * Time.deltaTime;

		speedScript.grounded = grounded;
	}
}
