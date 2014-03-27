using UnityEngine;
using System.Collections;

public class Speed : MonoBehaviour
{
	public float inputSpeed = 5;

	public float speedFinal;
	public float currentSpeed;
	public float energyBonus;
	public float currentHealth;
	public bool canMove = true;

	float sprintingMult;
	public float sprintingScale = 1;

	public bool sprinting = false;
	public bool grounded;

	public Controller controller;

	void Awake()
	{
		controller = GetComponent<Controller>();
	}
	
	public void Update ()
	{
		sprinting = Input.GetButton("Sprint");

		if(sprinting && grounded && Input.GetAxis("Vertical") > 0)
			sprintingScale += 0.333f * Time.deltaTime;
		else if(grounded)
			sprintingScale -= Time.deltaTime;

		sprintingScale *= Input.GetAxis("Vertical");

		sprintingScale = Mathf.Clamp(sprintingScale, 1, 2);

		sprintingMult = sprintingScale;

		currentSpeed = inputSpeed;

		if(currentHealth > 0.5f)
			currentSpeed *= currentHealth;
		else
			currentSpeed *= 0.5f;


		currentSpeed *= sprintingMult;
		currentSpeed += energyBonus;

		speedFinal = grounded ? currentSpeed : energyBonus;
		speedFinal = canMove ? speedFinal : 0;
		controller.speed = speedFinal;
	}
}