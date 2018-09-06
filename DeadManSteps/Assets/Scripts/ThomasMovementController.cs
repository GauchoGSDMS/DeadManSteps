//Codigo de animacion de Thomas Tews. Jugador.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

public class ThomasMovementController : MonoBehaviour {


	private InputHandler inputHandler;

	//1° Declarar un Singleton Acá -- Y ponerle el animator publico y estatico. 

	void Start()
	{
		inputHandler = new InputHandler();
	}

	private void Update()
	{
		if (inputHandler.HandleInput() != null)
		{
			Command cmd = inputHandler.HandleInput(); // Me devuelve que commando se va a ejecutar
			cmd.Execute(this.gameObject); //Ejecuta el comando especifico,aca podria ir cualquier cosa, siempre y cuando matchee con algun comando. 
		}	
	}
}

