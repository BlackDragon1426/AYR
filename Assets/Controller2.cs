using UnityEngine;
using System.Collections;

public class Controller2 : MonoBehaviour
{
	float squatingDistance = 0;
	public bool _grounded;
	bool grounded
	{
		get
		{
			Ray ray = new Ray(transform.position + new Vector3(0,1,0), -transform.up);
			
			RaycastHit[] hits = Physics.RaycastAll(ray, 1);
			
			float nearest = Mathf.Infinity;

			_grounded = false;
			
			for (int i = 0; i < hits.Length; i++)
			{
				if (!hits[i].collider.isTrigger && hits[i].distance < nearest)
				{
					nearest = hits[i].distance;
					squatingDistance = 1 - nearest;

					if(!_grounded)
						_grounded = true;
				}

			}

			return _grounded;
		}
		set
		{
			_grounded = value;
			bool triggered = false;
			if(!_grounded)
			{
				if(!triggered)
				{
					rigidbody.AddForce(rigidbody.velocity,ForceMode.VelocityChange);
					triggered = true;

				}
				rigidbody.useGravity = true;
			}
			else if(_grounded == true)
			{
				rigidbody.useGravity = false;
				triggered = false;
			}
		}
	}
	void FixedUpdate()
	{
		Debug.DrawRay(transform.position + new Vector3(0,1,0), new Vector3(0,-1,0), _grounded ? Color.green : Color.red );
		grounded = grounded;
		if(grounded == true)
		{

		}
		transform.Translate(0,squatingDistance * Time.deltaTime,0);
		rigidbody.AddForce (0,-rigidbody.velocity.y * squatingDistance,0,ForceMode.VelocityChange);
		Debug.Log (squatingDistance);
		rigidbody.velocity = rigidbody.velocity;
	}
}
