using UnityEngine;
using System.Collections;

public class PlayerMotion : MonoBehaviour
{
	public float playerSpeed = 0f;
	bool grounded = true;

	void FixedUpdate()
	{
		JumpChecker();
		Motion();

	}

	void JumpChecker()
	{
		bool jumped = false; //Prevents double jumps per one button tap while jumping from the ground

		if(Input.GetButtonDown("A") && grounded == true) {
			Jump();
			jumped = true;
			} else if (Input.GetButtonUp("A") && jumped == false) {
			Jump();
			jumped = false; // resets jumped (for future air jumps)
		} //Allows for holding the button so when you do get grounded you jump instantly
		  //Only jumps while in the air only if you let go of the button
		  //This allows trickier plays, while also preventing premature jumps that cost players un-nessesary energy
	}
	void Jump()
	{
		if (grounded == false) {
			//Energy Cost for jumping (NEEDS ATTENTION!!!)
			} else {
			//Jump force in target direction (NEEDS ATTENTION!!!)
		}
	}

	void Motion(){
		Vector3 targetDirection = new Vector3 (0, 0, 0);
		Vector3 energyAssistedMotion;
		if (grounded == false){

		}
	}
}
