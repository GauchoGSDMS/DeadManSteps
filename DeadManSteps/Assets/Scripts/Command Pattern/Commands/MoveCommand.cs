using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveCommand : Command {

	public static float speed = 5f; 
	private float rotateSpeed = 85f;
	public static float translation,rotation;


	public void Execute(GameObject actor,Animator anim)
	{
		translation *= speed;
		translation *= Time.deltaTime;
		rotation *= rotateSpeed;
		rotation *= Time.deltaTime;
		actor.transform.Translate(0,0,translation);
		actor.transform.Rotate(0,rotation,0);	
		anim.SetBool("isRunning",true);
	}
}
