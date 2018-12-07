using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

 public class MoveCommand : Command {

	/*  
	private float rotateSpeed = 90f;

	
	//new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
	 //direction * speed;
	private GameObject endRotation = new GameObject();
	*/
	Vector3 direction = new Vector3 ();
	public static float speed = 1.5f;
	Vector3 velocity = new Vector3();
	private float gravity = 9.81f;
	public static CharacterController cController ; 
	private Vector2 inputsAng ; 
	private Vector2 inputsMov;
	private float angle;
	
	
	//public float velocity = 5f;
	public float turnSpeed = 10f;

	Quaternion targetRotation;
	public static Transform cam;

	public void Execute(GameObject actor,Animator anim)
	{
		GetInputs();

		/* if ((Math.Abs(inputsAng.x) < 1) && (Math.Abs(inputsAng.y) < 1)) 
			return;
		*/

		CalculateDirection();

		Rotate(actor);
		
		Move(actor);	
		anim.SetFloat("BlendX",inputsMov.x);
		anim.SetFloat("BlendY",inputsMov.y);

		

		//actor.transform.Rotate

		/*
		actor.transform.Rotate(0,rotation*rotateSpeed*Time.deltaTime,0);
		 */
	
	}

	private void GetInputs()
	{
		inputsAng.x = Input.GetAxisRaw("Horizontal");
		inputsAng.y = Input.GetAxisRaw("Vertical");
		inputsMov.x = Input.GetAxis("Horizontal");
		inputsMov.y = Input.GetAxis("Vertical");
	}
	
	void CalculateDirection()
	{
		angle = Mathf.Atan2(inputsAng.x,inputsAng.y);
		angle = Mathf.Rad2Deg * angle;
		// Esto nose todavia como aplicarlo
		angle += cam.eulerAngles.y;
	}

	void Rotate(GameObject actor)
	{
		targetRotation = Quaternion.Euler(0,angle,0);
		actor.transform.rotation = Quaternion.Slerp(actor.transform.rotation,targetRotation,turnSpeed * Time.deltaTime);
	}

	void Move(GameObject actor)
	{
		actor.transform.position += actor.transform.forward * 3f * Time.deltaTime;
		/*direction = new Vector3(inputsMov.x,0,inputsMov.y);
		
		velocity = direction * speed;
		velocity = actor.transform.TransformDirection(velocity);

		velocity.y -= gravity;

		cController.Move(velocity * Time.deltaTime);*/
	}
 }
