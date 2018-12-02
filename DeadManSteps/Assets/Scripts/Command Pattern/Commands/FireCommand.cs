using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCommand : Command {

	public void Execute(GameObject actor,Animator anim)
	{
		// Esto si queres borralo, es una prueba para saber que devolvia el commando. 
		Debug.Log("Actor--->" + actor.name + "Cmd --> Fire" );

		

		//GameObject pistola = GameObject.FindWithTag("Pistol");
		GameObject pistola = ThomasMovementController.Instance.pistol;
		pistola.SetActive(true);
        Animator m_Animator = anim;
		
		//Clickeando mouse apuntar.
		

		//Controla la camara rotando al pj con el mouse.
		float mousex = Input.GetAxis ("Mouse X");
		if(mousex!=0){
			ThomasMovementController.Instance.transform.Rotate(0, mousex*4.2f, 0);
		}


		m_Animator.Play("PistolAim");
		pistola.SetActive(true);
		
		Disparar(pistola);
		

		//Si levantamos click derecho vuelve a idle.
		if (Input.GetMouseButtonUp(1)){
			m_Animator.Play("Idle");
		}


		
	}


	//Metodo para disparar.
    void Disparar(GameObject pistola){
    	//Layer Mask no borrar porque sino no anda
        int layerMask = 1 << 8;
        //No borrar porque sino no anda
        layerMask = ~layerMask;
        //Aca defino a quienes puedo matar con un raycast y a quienes no
		List<string> _listaDePuedoMatar = new List<string>(){ "Elizabeth", "Policia", "Otros" };

		//Este es el hitaso ...
        RaycastHit hit;
    	//Si apretas click izquierdo del mouse y mantenes apretado ...
        if (Input.GetMouseButton(0)){

			// Lanza un raycast ....
			if (Physics.Raycast(pistola.transform.position, pistola.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        	{
				//Si ese raycast no pega en el infinito (wooooooo) lo dibuja con color amarillo en la pantalla.
	            Debug.DrawRay(pistola.transform.position, pistola.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
				
				//Capturo el game object contra el que impacta el raycast.
				GameObject _objetoRayCasteado = hit.collider.gameObject;
				
				//Capturo el nombre del objeto en string con el que impacta el raycast
				string _objetoRayCasteadoNombre = _objetoRayCasteado.name;
				
				//Si ese objeto es elizabeth ...
            	if( _listaDePuedoMatar.Contains(_objetoRayCasteadoNombre) ){
					//Matarla, por ser mujer ... #NiUnaMenosLasBolas
					//Destroy(_objetoRayCasteado);
					Debug.Log("Destruyo objeto:"+_objetoRayCasteadoNombre);
				}

        	}
        	else
        	{
				//Si el raycast pega en el infinito, dibujar una linea blanca...
            	Debug.Log("Did not Hit");
        	}

		}
	}	
}
