using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

 public class MoveCommand : Command {

	public static float speed = 3.5F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public float rotateSpeed = 180.0F;
    private Vector3 moveDirection = Vector3.zero;
	public static CharacterController cController ;
	
	public void Execute(GameObject actor,Animator anim)
	{
	
    // Use this for initialization
		

		moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
		moveDirection = actor.transform.TransformDirection(moveDirection);
		moveDirection *= speed;
		
        moveDirection.y -= gravity * Time.deltaTime;
        cController.Move(moveDirection * Time.deltaTime);

        //Rotate Player
    	actor.transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime, 0);
		anim.SetFloat("BlendX",Input.GetAxis("Horizontal"));
		anim.SetFloat("BlendY",Input.GetAxis("Vertical"));
    }
 }
