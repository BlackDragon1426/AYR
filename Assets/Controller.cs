using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{
	public float speed;
    private float jumpPower = 5f;
                                              
    private const float jumpRayLength = 0.7f;                                          
	public bool grounded { get; private set; }
	private Vector2 input;
	Vector3 desiredMove;

	public Speed speedScript;

	IEnumerator GroundCheck()
	{
		int e = 0;
		while(true)
		{
			e++;
			print("e = " + e);
			yield return null;
			
		}
	}

    void Awake ()
	{
		grounded = true;
		StartCoroutine (GroundCheck());

		speedScript = GetComponent<Speed>();
	}
	
	public void FixedUpdate ()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		bool jump = Input.GetButton("Jump");

		input = new Vector2( h, v );

        // Ground Check:

		// Create a ray that points down from the centre of the character.
		Ray ray = new Ray(transform.position + new Vector3(0,2,0), -transform.up);
		
		// Raycast slightly further than the capsule (as determined by jumpRayLength)
		RaycastHit[] hits = Physics.RaycastAll(ray, 2);

        float nearest = Mathf.Infinity;
		float collisionHeightDifference;
		int closestRay = 0;

		grounded = false;
		rigidbody.useGravity = true;
	
		if (grounded || rigidbody.velocity.y < 0.1f)
		{
			for (int i = 0; i < hits.Length; i++)
			{
				if (!hits[i].collider.isTrigger && hits[i].distance < nearest)
				{
					nearest = hits[i].distance;
					grounded = true;
					rigidbody.useGravity = false;
					closestRay = i;
				}
			}
		}

		collisionHeightDifference = 2 - nearest;
//		Debug.Log (collisionHeightDifference);

		if(collisionHeightDifference < 0)
			collisionHeightDifference = 0;

//		if(collisionHeightDifference < 2)
//			transform.localPosition += hits[closestRay].point * Time.deltaTime;
		if(hits[closestRay].distance > 2)
		{
		Vector3 lockedTransformHeight = hits[closestRay].point - new Vector3(0,0.8f,0);
		if(collisionHeightDifference > 0.8)
			transform.position = lockedTransformHeight;
		}



		Debug.DrawRay(ray.origin, ray.direction * 1, grounded ? Color.green : Color.red );

		speedScript.grounded = grounded;


            
            // normalize input if it exceeds 1 in combined length:
		if (input.sqrMagnitude > 1) input.Normalize();

		// Get a vector which is desired move as a world-relative direction, including speeds
		if(grounded)
			desiredMove = transform.forward * input.y * speed + transform.right * input.x * speed;
		Debug.Log (desiredMove);


		// preserving current y velocity (for falling, gravity)
		float yv = rigidbody.velocity.y;


		// add jump power
		if (grounded && jump) {
			yv += jumpPower;
			rigidbody.AddForce(desiredMove * speed, ForceMode.VelocityChange);
//			grounded = false;
		}
			
		rigidbody.velocity = desiredMove + Vector3.up * yv;

	}
}
