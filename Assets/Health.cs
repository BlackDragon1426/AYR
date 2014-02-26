using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
	[Range(0f, 1000f)]
	public float health = 1000;

	float headHealth = 1000;
	float neckHealth = 400;
	
	float lHandHealth = 50;
	float lForearmHealth = 150;
	float lUpperarmHealth = 200;
	
	float rHandHealth = 50;
	float rForearmHealth = 150;
	float rUpperarmHealth = 200;
	
	float coreHealth = 1000;
	
	float lUpperlegHealth = 350;
	float lLowerlegHealth = 200;
	float lFootHealth = 100;
	
	float rUpperlegHealth = 350;
	float rLowerlegHealth = 200;
	float rFootHealth = 100;

	public Speed Currenthealth;

	void Awake()
	{
		Currenthealth = GetComponent<Speed>();
	}
	
	void FixedUpdate()
	{
		Currenthealth.currentHealth = health / 1000;
	}
}
