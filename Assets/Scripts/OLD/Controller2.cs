using UnityEngine;
using System.Collections;

public class Controller2 : MonoBehaviour
{
	float squatingDistance = 0;
	public bool _grounded;
	float time = 0;
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
//					rigidbody.AddForce(rigidbody.velocity.x,0,rigidbody.velocity.z,ForceMode.VelocityChange);
					triggered = true;

				}
				GetComponent<Rigidbody>().useGravity = true;

			}
			else if(_grounded == true)
			{
				GetComponent<Rigidbody>().useGravity = false;
//				rigidbody.AddForce(0,squatingDistance * squatingDistance / 2 * time,0,ForceMode.VelocityChange);
				transform.Translate(0,1 - squatingDistance * Time.fixedDeltaTime,0);
				triggered = false;

			}
		}
	}
	void FixedUpdate()
	{
		Debug.DrawRay(transform.position + new Vector3(0,1,0), new Vector3(0,-1,0), _grounded ? Color.green : Color.red );
		grounded = grounded;
		if(!grounded)
		{
			time += Time.fixedDeltaTime;
		}	
		Debug.Log(time + " Seconds since being in the air");
//		rigidbody.velocity = rigidbody.velocity;
	}
}
