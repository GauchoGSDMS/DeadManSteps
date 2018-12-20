using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleCommand : Command {

	public void Execute(GameObject actor,Animator anim)
	{
		if (anim.GetBool("isRunning"))
		{
			anim.SetBool("isRunning",false);
			MoveCommand.speed = 2f;
		}
	}
}
