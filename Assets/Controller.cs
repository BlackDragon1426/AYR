using UnityEngine;

public class Controller : MonoBehaviour
{
	public float speed;
    private float jumpPower = 5f;

//	[SerializeField] private AdvancedSettings advanced = new AdvancedSettings(); 
	
//	[System.Serializable]
//    public class AdvancedSettings 
//    {
//        public float gravityMultiplier = 1f;
//        public PhysicMaterial zeroFrictionMaterial;
//        public PhysicMaterial highFrictionMaterial;
//    }

//    private SphereCollider sphere;                                                  
    private const float jumpRayLength = 0.7f;                                          
	public bool grounded { get; private set; }
	private Vector2 input;
	Vector3 desiredMove;

	public Speed speedGrounded;

    void Awake ()
	{
        // Set up a reference to the capsule collider.
//	    sphere = collider as SphereCollider;
		grounded = true;

		speedGrounded = GetComponent<Speed>();
	}

	
	public void FixedUpdate ()
	{
        // Read input
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
				}
			}
		}

		collisionHeightDifference = 2 - nearest;
		Debug.Log (collisionHeightDifference);

		if(collisionHeightDifference < 0)
			collisionHeightDifference = 0;
		transform.position = transform.position + new Vector3(0, collisionHeightDifference, 0);

		Debug.DrawRay(ray.origin, ray.direction * 1, grounded ? Color.green : Color.red );

		speedGrounded.grounded = grounded;


            
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

        // Use low/high friction depending on whether we're moving or not
//        if (desiredMove.magnitude > 0)
//		{
//          collider.material = advanced.zeroFrictionMaterial;
//			rigidbody.AddForce(Physics.gravity * (advanced.gravityMultiplier - 1));
//		}
//		else if (desiredMove.magnitude == 0 && !grounded)
//		{
//			collider.material = advanced.highFrictionMaterial;
//		}
	}
}
