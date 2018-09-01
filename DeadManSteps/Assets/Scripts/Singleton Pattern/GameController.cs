using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
	#region Singleton
	private static GameController _instance;

	public static GameController Instance 
	{
		get
		{
			if (_instance != null)
			{
				GameObject gc = new GameObject("GameController");
				gc.AddComponent<GameController>();
				
			}
			return _instance;
		}
	}
	#endregion
	
	public delegate void UpPuntuation(int points);
	public static event UpPuntuation upPoints;
	
	void Awake()
	{
		_instance = this;	
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			// Damage enemy
			if (upPoints != null)
			{
				upPoints(50);
			}
		}
	}	
}
