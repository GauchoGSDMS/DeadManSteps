using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCommand : Command {

	public void Execute(GameObject actor,Animator anim)
	{
		// Esto si queres borralo, es una prueba para saber que devolvia el commando. 
		Debug.Log("Actor--->" + actor.name + "Cmd --> Fire" );

		// Aca tenes que agregar toda la logica del cambio de las animaciones, el disparo y la movida de la camara. 
		// Necesariamente todo eso tiene que pasar cuando entre aca. Cuando salga hay que controlar que todo private void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info) {
		// reestablezca y vuelva la camara y demas a su lugar.

		float mousex = Input.GetAxis ("Mouse X");
		if(mousex!=0){
         	ThomasMovementController.Instance.transform.Rotate(0, mousex*4.2f, 0);
		}
	}	
}
