using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallBackSystem : MonoBehaviour {

	public delegate void ReciboElMensaje(); // Esto encapsula el methodo

	// Use this for initialization
	void Start () 
	{
		ReciboElMensaje prueba = EscribirMensaje; // Es como que creo una variable del tipo del methodo.
		prueba();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void EscribirMensaje()
	{
		Debug.Log("EscribirMensaje() Fue llamado");
	}
}
