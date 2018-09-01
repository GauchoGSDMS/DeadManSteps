using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	int acuPoints = 0;

	// Use this for initialization
	void Start () 
	{
		GameController.upPoints	+= RaisePoints;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void RaisePoints(int points)
	{
		acuPoints += points;
		Debug.Log(acuPoints);
	}

	void OnDisable()
	{
		GameController.upPoints -= RaisePoints;
	}
}
