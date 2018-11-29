using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThomasShoot : MonoBehaviour
{
	int _cantDisparos = 5;
	public GameObject pistola;

    void Update()
    {    
    	pistola.SetActive(false);
        Animator m_Animator = GetComponent<Animator>();
		//Clickeando mouse apuntar.
		if (Input.GetMouseButton(1)){
			m_Animator.Play("PistolAim");
			pistola.SetActive(true);
			Disparar();
		}

		//Si levantamos click derecho vuelve a idle.
		if (Input.GetMouseButtonUp(1)){
			m_Animator.Play("Idle");
		}

		
		
    }

    //Metodo para disparar.
    void Disparar(){
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
					Destroy(_objetoRayCasteado);
				}

        	}
        	else
        	{
				//Si el raycast pega en el infinito, dibujar una linea blanca...
	            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            	Debug.Log("Did not Hit");
        	}

		}
    }

	

}	