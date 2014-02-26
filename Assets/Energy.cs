using UnityEngine;
using System.Collections;

public class Energy : MonoBehaviour
{
	[Range(-10, 1000)]
	public float quickAccessEnergy = 1000;

	[Range(0, 1000000)]
	public float energyChipLevel = 1000000;

	
	public float rechargeRate = 100;
	float drainRate;

	public bool systemShocked = false;

	public Speed Energybonus;

	void Awake()
	{
		Energybonus = GetComponent<Speed>();

		quickAccessEnergy = 1000;
	}
	
	void FixedUpdate()
	{

		drainRate = rechargeRate;

		if(quickAccessEnergy < 1000)
		{
			if(energyChipLevel > 0)
			{
				quickAccessEnergy += rechargeRate * Time.fixedDeltaTime;
				energyChipLevel -= drainRate * Time.fixedDeltaTime;
			}

			if(quickAccessEnergy < 0)
			{
				systemShocked = true;
			}
			quickAccessEnergy = Mathf.Clamp(quickAccessEnergy, 0, 1000);
		}

		rechargeRate = systemShocked ? 0 : 100;
		Energybonus.energyBonus = quickAccessEnergy / 1000 * 5;
	}
}

