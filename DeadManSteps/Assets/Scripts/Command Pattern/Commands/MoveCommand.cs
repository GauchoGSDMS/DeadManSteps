using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

 public class MoveCommand : Command {

	public static float speed = 3.5f; 
	//private float rotateSpeed = 85f;
	private float gravity = 9.81f;
	private float rotateSpeed = 85f;
	public static float translation,rotation;
	public static CharacterController cController ; 
	Vector3 direction = new Vector3 ();//new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
	Vector3 velocity = new Vector3(); //direction * speed;
		


	public void Execute(GameObject actor,Animator anim)
	{
		
		anim.SetFloat("BlendX",rotation);
		anim.SetFloat("BlendY",translation);

		direction = new Vector3(rotation,0,translation);

		velocity = direction * speed;

		velocity.y -= gravity;

		velocity = actor.transform.TransformDirection(velocity);

		//actor.transform.Rotate

		cController.Move(velocity * Time.deltaTime);

		/* translation *= speed;
		translation *= speed;
		translation *= Time.deltaTime;
		rotation *= rotateSpeed;
		rotation *= Time.deltaTime;
		actor.transform.Translate(0,0,translation);
		actor.transform.Rotate(0,rotation,0);	
		actor.transform.Rotate(0,rotation,0);	
		anim.SetBool("isRunning",true);*/
	}
 }
