using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleCommand : Command {

	public void Execute(GameObject actor,Animator anim)
	{
		anim.SetBool("isRunning",false);
	}
}
