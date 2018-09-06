using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Esta clase es la que me va a manejar todas las clases de comandos segun los inputs que tuvo. 

public class InputHandler {

	private Command CmdJump,CmdMove,CmdFire;

	public Command HandleInput()
	{
		if (Input.GetAxis("Jump") != 0) 
		{ 
			// Significa que estoy queriendo saltar.
			CmdJump = new JumpCommand();
			return CmdJump;
		}

		if ((Input.GetAxis("Horizontal") !=0 || Input.GetAxis("Vertical") !=0))
		{
			CmdMove = new MoveCommand();
			MoveCommand.rotation = Input.GetAxis("Horizontal");
			MoveCommand.translation = Input.GetAxis("Vertical");
			return CmdMove;
		}else
		{
			
		}

		/*if (Input.GetAxis("Fire1")!=0)
		{
			Por ahora esta animacion la vamos a dejar de lado. Por que nosotros tendriamos 2 pasos anteriores.
		}*/

		return null;// Si presiono algo que no sea lo que esta arriba GG. 

	} 

}
