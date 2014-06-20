using UnityEngine;
using System.Collections;

namespace AYRConditions
{
	public class Condition : MonoBehaviour
	{
		public class Health 
		{
			[Range(0f, 1000f)]
			public float health = 1000;
			
			public float headHealth = 250;
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
			
			public float Crippleness()
			{
				lArmHealth = lHandHealth + lForearmHealth + lUpperarmHealth;
				lLegHealth = lUpperlegHealth + lLowerlegHealth + lFootHealth;
				rArmHealth = rHandHealth + rForearmHealth + rUpperarmHealth;
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
				
				speedCripple = 0;
				
				speedCripple += (lArmHealth + rArmHealth) / 2 / 275 * 0.15f;
				speedCripple += (lLegHealth + rLegHealth) / 2 / 400 * 0.45f;
				speedCripple += (coreHealth / 1000) * 0.4f;
				speedCripple *= (headHealth / 250);
				speedCripple = Mathf.Clamp01(speedCripple);

				if(health <= 0 || headDead == true)
					alive = false;
				else
					alive = true;
				
				if(alive == false || lLegDead == true && rLegDead == true)
					speedCripple = 0;

				return speedCripple;
			}
		}

		public class Stamina
		{
			float oxygenLevel = 1;
			float bloodLevel = 1;

			float overallStamina;

			void update()
			{
				overallStamina = oxygenLevel * bloodLevel;
			}
		}


	}
}