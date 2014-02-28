using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
	[Range(0f, 1000f)]
	public float health = 1000;

	float headHealth = 250;
	bool headDead = false;
	
	float lHandHealth = 25;
	float lForearmHealth = 100;
	float lUpperarmHealth = 150;
	float lArmHealth;
	bool lArmDead = false;
	
	float rHandHealth = 25;
	float rForearmHealth = 100;
	float rUpperarmHealth = 150;
	float rArmHealth;
	bool rArmDead = false;
	
	float coreHealth = 1000;
	
	float lUpperlegHealth = 200;
	float lLowerlegHealth = 125;
	float lFootHealth = 75;
	float lLegHealth;
	bool lLegDead = false;
	
	float rUpperlegHealth = 200;
	float rLowerlegHealth = 125;
	float rFootHealth = 75;
	float rLegHealth;
	bool rLegDead = false;

	float speedCripple = 0;

	bool alive = true;

	public Speed Speed;

	void Awake()
	{
		Speed = GetComponent<Speed>();
	}
	
	void FixedUpdate()
	{
		lArmHealth = lHandHealth + lForearmHealth + lUpperarmHealth;
		lLegHealth = lUpperlegHealth + lLowerlegHealth + lFootHealth;
		rArmHealth = rHandHealth + rForearmHealth + rForearmHealth;
		rLegHealth = rUpperlegHealth + rLowerlegHealth + rFootHealth;

		if(lLegHealth <= 0)
			lLegDead = true;
		else
			lLegDead = false;
		if(rLegHealth <= 0)
			rLegDead = true;
		else
			rLegDead = false;

		if(lUpperlegHealth <= 0 || lLowerlegHealth <= 0 || lFootHealth <= 0)
			lLegDead = true;
		if(rUpperlegHealth <= 0 || rLowerlegHealth <= 0 || rFootHealth <= 0)
			rLegDead = true;


		if(health <= 0 || headDead == true)
			alive = false;
		else
			alive = true;

//		Speed.currentHealth = health / 1000;
		if(alive == false || lLegDead == true && rLegDead == true)
			Speed.canMove = false;

		speedCripple = 0;

		speedCripple += (lArmHealth + rArmHealth) / 2 / 275 * 0.15f;
		speedCripple += (lLegHealth + rLegHealth) / 2 / 400 * 0.45f;
		speedCripple += (coreHealth / 1000) * 0.40f;
		speedCripple *= (headHealth / 250);
		speedCripple = Mathf.Clamp01(speedCripple);
		Debug.Log(speedCripple);
	}
}























