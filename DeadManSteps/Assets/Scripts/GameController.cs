using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	
	public GameObject Phone;
	public static bool isPhoneAlive;
	public static bool isAmuletAlive = true;
	public static bool isGameOver;
	public GameObject cam;
	public GameObject amulet; 
	public GameObject wallToActivate;
	public GameObject pnlGameOver;
	public static bool isDistractionOk;
	public GameObject doorWin;
	private GameObject[] lstGuards;
	

	void Start()
	{
		Object.DontDestroyOnLoad(cam);
	}
	
	void Update () 
	{
		CheckPhone();
		CheckAmulet();
		CheckDistraction();	
		CheckGameOver();
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
		if(!isAmuletAlive){
			doorWin.GetComponent<BoxCollider>().enabled = true;
			doorWin.GetComponent<WinDoor>().enabled = true;
		}
	}

	void CheckDistraction()
	{
		if(isDistractionOk)
		{
			if(lstGuards == null)
			{
				lstGuards = GameObject.FindGameObjectsWithTag("GuardSotano");
				
				foreach (GameObject guard in lstGuards)
				{
					guard.GetComponent<Patrol>().enabled = true;
					guard.GetComponent<FieldOfView>().enabled = true;
					guard.GetComponent<Animator>().SetBool("isWalking",true);
					wallToActivate.SetActive(false);
				}
			}			
		}
	}

	void CheckGameOver()
	{
		if(isGameOver)
		{
			pnlGameOver.SetActive(true);
			Time.timeScale = 0f;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
		else
		{
			pnlGameOver.SetActive(false);
			Time.timeScale = 1f;
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}
	}
}
