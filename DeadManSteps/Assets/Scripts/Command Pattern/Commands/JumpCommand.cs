using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCommand : Command {

	public void Execute(GameObject actor)
	{
		actor.GetComponent<Rigidbody>().AddForce(Input.GetAxis("Horizontal"),30f,0);	
	}
}
