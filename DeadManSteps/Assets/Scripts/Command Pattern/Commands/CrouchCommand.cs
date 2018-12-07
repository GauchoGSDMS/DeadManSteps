using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchCommand : Command
{

	public void Execute(GameObject actor,Animator anim)
	{
		/*if (!anim.GetBool("isCrouching"))
		{
			anim.SetBool("isCrouching",true);
			anim.SetTrigger("Crouch");
			anim.SetBool("isRunning",false);
			anim.SetBool("CanJump",false);
			MoveCommand.speed = 1.5f;
		}else
		{
			anim.SetBool("isCrouching",false);
			MoveCommand.speed = 3f;
			anim.SetBool("CanJump",true);
		}*/
	}

}
