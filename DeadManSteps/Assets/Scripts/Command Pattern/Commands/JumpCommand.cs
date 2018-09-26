using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCommand : Command {

	public void Execute(GameObject actor,Animator anim)
	{
			anim.SetTrigger("Jump");
			
	}
}
