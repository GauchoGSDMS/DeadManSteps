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
			MakeCrouch(anim);			
		}
	}

	void MakeCrouch(Animator anim)
	{
		if (anim.GetBool("isCrouching"))
			{
				anim.SetBool("isCrouching",false);
				MoveCommand.speed = 3.5f;
			}
			else
			{
				anim.SetBool("isCrouching",true);
				MoveCommand.speed = 1.5f;
			}
	}
}
