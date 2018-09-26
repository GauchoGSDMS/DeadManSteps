using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Esta clase es la que me va a manejar todas las clases de comandos segun los inputs que tuvo. 

public class InputHandler {

	private Command CmdJump,CmdMove,CmdFire,CmdIdle,CmdCrouch,CmdPickUp;

	public Command HandleInput()
	{

		if (Input.GetKeyDown(KeyCode.Space) && ThomasMovementController.Instance.anim.GetBool("CanJump")) 
		{ 
			// Significa que estoy queriendo saltar.
			CmdJump = new JumpCommand();
			return CmdJump;
		}

		if(Input.GetKeyDown(KeyCode.C))
		{
			CmdCrouch = new CrouchCommand();
			return CmdCrouch;
		}

		if (Input.GetAxis("Horizontal")==0 && Input.GetAxis("Vertical") == 0)
		{
			CmdIdle = new IdleCommand();
			return CmdIdle;
		}

		if (Input.GetKeyDown(KeyCode.E))
		{
			CmdPickUp = new PickUpCommand();
			return CmdPickUp;
		}

		if (((Input.GetAxis("Horizontal") !=0 || Input.GetAxis("Vertical") !=0)) && !ThomasMovementController.Instance.anim.GetBool("isTaking"))
		{
			CmdMove = new MoveCommand();
			MoveCommand.rotation = Input.GetAxis("Horizontal");
			MoveCommand.translation = Input.GetAxis("Vertical");
			return CmdMove;
		}

		return null;// Si presiono algo que no sea lo que esta arriba GG. 

	} 

}
