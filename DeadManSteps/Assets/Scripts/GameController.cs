using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	
	public GameObject Phone;
	public static bool isPhoneAlive;
	public static bool isAmuletAlive;
	public GameObject cam;
	public GameObject amulet; 

	// Update is called once per frame

	void Start()
	{
		//Object.DontDestroyOnLoad(this);
		Object.DontDestroyOnLoad(cam);
		Cursor.visible = false;
	}
	
	void Update () 
	{
	
		CheckPhone();
		CheckAmulet();	
	}


	void CheckPhone()
	{
		if(Phone == null)
			isPhoneAlive = false;
		else
			isPhoneAlive = true;
	}

	void CheckAmulet()
	{
		if(amulet == null)
			isAmuletAlive = false;
		else
			isAmuletAlive = true;
	}
}
