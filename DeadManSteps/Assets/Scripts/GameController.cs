using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	
	public GameObject Phone;
	public static bool isPhoneAlive;

	// Update is called once per frame
	void Update () 
	{
		CheckPhone();
	}

	void CheckPhone()
	{
		if(Phone == null)
		{
			Debug.Log("El telefono no se encuentra.");
			isPhoneAlive = false;
		}
		else
		{
			Debug.Log("El telefono se encuentra.");
			isPhoneAlive = true;
		}
	}



}
