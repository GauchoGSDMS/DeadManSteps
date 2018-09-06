﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command {

	private float speed = 3f; 
	private float rotateSpeed = 85f;
	public static float translation,rotation;


	public void Execute(GameObject actor)
	{
		
		translation *= speed;
		translation *= Time.deltaTime;
		rotation *= rotateSpeed;
		rotation *= Time.deltaTime;
		actor.transform.Translate(0,0,translation);
		actor.transform.Rotate(0,rotation,0);	

	}
}
