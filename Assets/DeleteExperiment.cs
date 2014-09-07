using UnityEngine;
using System.Collections;

public class DeleteExperiment : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		Vector3 oldvelocity = new Vector3(0,0,0);
		Vector3 newvelocity = rigidbody.velocity;

		if(Input.GetKey(KeyCode.Space))
		{
			transform.position = new Vector3(0,0,0);
			rigidbody.velocity = new Vector3(0,0,0);
		}
		float acceleration = newvelocity.magnitude - oldvelocity.magnitude;




		Debug.Log (acceleration);

		oldvelocity = newvelocity;
	}
}
