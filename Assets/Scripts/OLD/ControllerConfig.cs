using UnityEngine;
using System.Collections;

public class ControllerConfig : MonoBehaviour
{
	void Update ()
	{
		if(Input.GetButtonDown("A"))
		{
			Debug.Log("A HIT");
		}
		if(Input.GetButtonDown("B"))
		{
			Debug.Log("B HIT");
		}
		if(Input.GetButtonDown("X"))
		{
			Debug.Log("X HIT");
		}
		if(Input.GetButtonDown("Y"))
		{
			Debug.Log("Y HIT");
		}


		if(Input.GetButtonDown("Back"))
		{
			Debug.Log("Back HIT");
		}
		if(Input.GetButtonDown("Start"))
		{
			Debug.Log("Start HIT");
		}


		if(Input.GetButtonDown("LB"))
		{
			Debug.Log("LB HIT");
		}
		if(Input.GetButtonDown("RB"))
		{
			Debug.Log("RB HIT");
		}


		if(Input.GetAxis("LAH") == 1)
		{
			Debug.Log("LAH = 1");
		}
		if(Input.GetAxis("LAH") == -1)
		{
			Debug.Log("LAH = -1");
		}
		if(Input.GetAxis("LAV") == 1)
		{
			Debug.Log("LAV = 1");
		}
		if(Input.GetAxis("LAV") == -1)
		{
			Debug.Log("LAV = -1");
		}

		if(Input.GetButtonDown("LAC"))
		{
			Debug.Log("LAC HIT");
		}


		if(Input.GetAxis("RAH") == 1)
		{
			Debug.Log("RAH = 1");
		}
		if(Input.GetAxis("RAH") == -1)
		{
			Debug.Log("RAH = -1");
		}
		if(Input.GetAxis("RAV") == 1)
		{
			Debug.Log("RAV = 1");
		}
		if(Input.GetAxis("RAV") == -1)
		{
			Debug.Log("RAV = -1");
		}

		if(Input.GetButtonDown("RAC"))
		{
			Debug.Log("RAC HIT");
		}


		if(Input.GetAxis("DPH") == 1)
		{
			Debug.Log("DPH = 1");
		}
		if(Input.GetAxis("DPH") == -1)
		{
			Debug.Log("DPH = -1");
		}
		if(Input.GetAxis("DPV") == 1)
		{
			Debug.Log("DPV = 1");
		}
		if(Input.GetAxis("DPV") == -1)
		{
			Debug.Log("DPV = -1");
		}


		if(Input.GetAxis("LT") == 1)
		{
			Debug.Log("LT = 1");
		}
		if(Input.GetAxis("RT") == 1)
		{
			Debug.Log("RT = 1");
		}
	}
}
