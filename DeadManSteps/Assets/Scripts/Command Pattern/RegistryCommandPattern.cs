using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class RegistryCommandPattern 
{
	//public static GameObject CURRENT_DIMITRI; Esto lo usaba en caso de que cambie el elemento seleccionado. 
	public static GameObject DIMITRI = GameObject.Find("Dimitri");
	public static MonoBehaviour DIMITRI_MONOBEHAVIOUR;
}
