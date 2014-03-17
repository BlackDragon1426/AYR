using UnityEngine;

public class Controller : MonoBehaviour
{
	public float speed;
    private float jumpPower = 5f;

	[SerializeField] private AdvancedSettings advanced = new AdvancedSettings(); 
	
	[System.Serializable]
    public class AdvancedSettings 
    {
        public float gravityMultiplier = 1f;
        public PhysicMaterial zeroFrictionMaterial;
        public PhysicMaterial highFrictionMaterial;
    }

    private SphereCollider sphere;                                                  
    private const float jumpRayLength = 0.7f;                                          
	public bool grounded { get; private set; }
	private Vector2 input;
	Vector3 desiredMove;

	public Speed speedGrounded;

    void Awake ()
	{
        // Set up a reference to the capsule collider.
	    sphere = collider as SphereCollider;
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
		Ray ray = new Ray(transform.position , -transform.up);
		
		// Raycast slightly further than the capsule (as determined by jumpRayLength)
		RaycastHit[] hits = Physics.RaycastAll(ray, sphere.radius * 1.15f / 2);

	       
        float nearest = Mathf.Infinity;
	
		if (grounded || rigidbody.velocity.y < 0.1f)
		{
			// Default value if nothing is detected:
			grounded = false;
            
            // Check every collider hit by the ray
			for (int i = 0; i < hits.Length; i++)
			{
				// Check it's not a trigger
				if (!hits[i].collider.isTrigger && hits[i].distance < nearest)
				{
					// The character is grounded, and we store the ground angle (calculated from the normal)
					grounded = true;
					nearest = hits[i].distance;
					//Debug.DrawRay(transform.position, groundAngle * transform.forward, Color.green);
				}
			}
		}

		Debug.DrawRay(ray.origin, ray.direction * sphere.radius, grounded ? Color.green : Color.red );

		speedGrounded.grounded = grounded;
		

            
            // normalize input if it exceeds 1 in combined length:
		if (input.sqrMagnitude > 1) input.Normalize();

		// Get a vector which is desired move as a world-relative direction, including speeds
		if(grounded)
			desiredMove = transform.forward * input.y * speed + transform.right * input.x * speed;


		// preserving current y velocity (for falling, gravity)
		float yv = rigidbody.velocity.y;


		// add jump power
		if (grounded && jump) {
			yv += jumpPower;
			rigidbody.AddForce(desiredMove * speed, ForceMode.VelocityChange);
			grounded = false;
		}
			
		rigidbody.velocity = desiredMove + Vector3.up * yv;

        // Use low/high friction depending on whether we're moving or not
        if (desiredMove.magnitude > 0)
		{
            collider.material = advanced.zeroFrictionMaterial;
//			rigidbody.AddForce(Physics.gravity * (advanced.gravityMultiplier - 1));
		}
		else if (desiredMove.magnitude == 0 && !grounded)
		{
			collider.material = advanced.highFrictionMaterial;
		}
	}
}
