using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Esta clase es la que me va a manejar todas las clases de comandos segun los inputs que tuvo. 

public class InputHandler {


	public Command HandleInput()
	{

		/*if (Input.GetAxis("Jump") != 0 && ThomasMovementController.Instance.anim.GetBool("CanJump")) 
		{ 
			// Significa que estoy queriendo saltar.
			return new JumpCommand();
		}*/

		if(Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
		{
			return new RunCommand();
		}

		if(Input.GetMouseButton(1))
		{
			return new FireCommand();
		}
		
		if(Input.GetKeyDown(KeyCode.C))
		{
			return new CrouchCommand();
		}

		if (Input.GetAxis("Horizontal")==0 && Input.GetAxis("Vertical") == 0)
		{
			return new IdleCommand();
		}

		if (Input.GetKeyDown(KeyCode.E))
		{
			return new PickUpCommand();
		}

		if (((Input.GetAxis("Horizontal") !=0 || Input.GetAxis("Vertical") !=0)))// && !ThomasMovementController.Instance.anim.GetBool("isTaking"))
		{
			MoveCommand.cController = ThomasMovementController.Instance.GetComponent<CharacterController>();
			return new MoveCommand();
		}

		return null;// Si presiono algo que no sea lo que esta arriba GG. 

	} 

	
}
