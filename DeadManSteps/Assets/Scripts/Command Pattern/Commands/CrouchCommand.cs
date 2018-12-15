using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchCommand : Command
{

	public void Execute(GameObject actor,Animator anim)
	{
		if(anim.GetBool("isRunning"))
		{
			anim.SetBool("isRunning",false);
			MakeCrouch(anim);	
		}else
		{
<<<<<<< Updated upstream
			MakeCrouch(anim);			
=======
			anim.SetBool("isCrouching",false);
			MoveCommand.speed = 3f;
			anim.SetBool("CanJump",true);
		}*/

		if (anim.GetBool("isCrouching"))
		{
			anim.SetBool("isCrouching",false);
			MoveCommand.speed = 3.5f;
		}
		else
		{
			anim.SetBool("isCrouching",true);
			MoveCommand.speed = 1.5f;
>>>>>>> Stashed changes
		}
	}

	void MakeCrouch(Animator anim)
	{
		if (anim.GetBool("isCrouching"))
			{
				anim.SetBool("isCrouching",false);
				MoveCommand.speed = 2f;
			}
			else
			{
				anim.SetBool("isCrouching",true);
				MoveCommand.speed = 1f;
			}
	}
}
