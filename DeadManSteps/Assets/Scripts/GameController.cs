using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	
	public GameObject Phone;
	public static bool isPhoneAlive;
	public GameObject camera;

	// Update is called once per frame

	void Start()
	{
		Object.DontDestroyOnLoad(camera);
		Cursor.visible = false;
	}

	void Update () 
	{
		CheckPhone();	
	}

	void CheckPhone()
	{
		if(Phone == null)
			isPhoneAlive = false;
		else
			isPhoneAlive = true;
	}
}
