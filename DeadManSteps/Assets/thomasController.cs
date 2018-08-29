using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thomasController : MonoBehaviour {

	// Use this for initialization
	MainMenu mm = new MainMenu();
	public static bool gameIsPaused = false;


	void Start () 
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;	
	}


	
	// Update is called once per frame
	void Update () 
	{
		
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			mm.gameIsPaused = true;
			//GUI y que la camara se deje de mover despues de esto.
			//Aca iria la pregunta si esta pausado... Y deberia de tirar a las 2 funciones la que pausa y abre el panell
			//Y la que inhabilita el juego.  
		} 	
	}
}
