using UnityEngine;
using System.Collections;

public class ASSSKLLKSKLSKLSKLL : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (Input.GetKeyDown(KeyCode.Q))
			rigidbody.AddForce(0,10,0,ForceMode.VelocityChange);
		if (Input.GetKeyDown(KeyCode.E))
			rigidbody.AddForce(10,0,10,ForceMode.VelocityChange);
		if(Input.GetKeyDown(KeyCode.Z))
			transform.position = new Vector3(10,10,10);
	}
}
