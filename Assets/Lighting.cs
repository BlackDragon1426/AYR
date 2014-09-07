using UnityEngine;
using System.Collections;

public class Lighting : MonoBehaviour
{
	void Start()
	{
	}

	void FixedUpdate()
	{

		StartCoroutine("FuckBitchesGetMoney");
	}

	IEnumerator FuckBitchesGetMoney()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			rigidbody.AddForce(0,9.81f,0,ForceMode.Acceleration);
			rigidbody.AddForce(0,10,0,ForceMode.VelocityChange);
		}
		yield return new WaitForFixedUpdate();
	}
	
}
