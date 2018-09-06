using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Esta clase, la aplico aisladamente por que tenia 3 cubos. Yo tengo solo a dimitri, por ende puedo usar this.GameObject.

public sealed class RegistryCommandPattern 
{
	//public static GameObject CURRENT_DIMITRI; Esto lo usaba en caso de que cambie el elemento seleccionado. 
	public static GameObject DIMITRI = GameObject.Find("Dimitri");
	public static MonoBehaviour DIMITRI_MONOBEHAVIOUR;
}
