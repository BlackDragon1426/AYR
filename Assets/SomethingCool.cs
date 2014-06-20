using UnityEngine;
using System.Collections;
using AYRConditions;

public class SomethingCool : MonoBehaviour
{
	public Condition.Health health = new Condition.Health();
	public float dickSause = 100;
	void Update()
	{
		health.headHealth = dickSause;
		float crippleness = health.Crippleness();
		Debug.Log(crippleness);

	}
}
