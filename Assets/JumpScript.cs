using UnityEngine;
using System.Collections;

public class JumpScript : MonoBehaviour
{

	Rigidbody physicsBody ;

	void Start()
	{
		physicsBody  = GetComponent<Rigidbody> ();
	}

	public Vector3 jumpDirection = new Vector3 (0,0,0); 

	public float cake = 0; 

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Jump();
		}
	}
	
	public void Jump()
	{
	
		physicsBody.velocity += new Vector3 (0, -(0.5f * Physics.gravity.y * Mathf.Pow(((jumpDirection.z / physicsBody.velocity.z) / 2) , 2) - jumpDirection.y) / (jumpDirection.z / physicsBody.velocity.z / 2) , 0);
	}
}
