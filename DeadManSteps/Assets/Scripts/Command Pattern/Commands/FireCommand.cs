using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCommand : Command {

	public void Execute(GameObject actor)
	{
		Debug.Log("Actor--->" + actor.name + "Cmd --> Fire" );
	}
}
