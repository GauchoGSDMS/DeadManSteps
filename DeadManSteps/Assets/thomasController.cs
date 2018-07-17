using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thomasController : MonoBehaviour {

	// Use this for initialization
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
			//GUI y que la camara se deje de mover despues de esto. 

		} 	
	}
}
