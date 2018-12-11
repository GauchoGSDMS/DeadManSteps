using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunCommand : Command 
{
	public void Execute(GameObject actor, Animator anim)
	{
		if(anim.GetBool("isRunning"))
		{
			anim.SetBool("isRunning",false);
			MoveCommand.speed = 3.5f;
		}else
		{
			anim.SetBool("isRunning",true);
			MoveCommand.speed = 6.5f;
		}
	}
}
