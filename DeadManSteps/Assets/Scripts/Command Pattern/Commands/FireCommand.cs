using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCommand : Command {

	public void Execute(GameObject actor,Animator anim)
	{


		GameObject pistola = ThomasMovementController.Instance.pistol;
		pistola.SetActive(true);
        Animator m_Animator = anim;
		
		//Clickeando mouse apuntar.

		if (Input.GetMouseButton(1)&&ThomasMovementController.Instance.disparando==false){
		m_Animator.SetBool("isAiming",true);
		pistola.SetActive(true);
		}

		//Si levantamos click derecho vuelve a idle.
		if (Input.GetMouseButtonUp(1)){
			m_Animator.SetBool("isAiming",false);
		}
		if (Input.GetMouseButton(0))
		{
			Disparar(pistola);
			anim.SetTrigger("Shoot");
		}		
	}


	//Metodo para disparar.
    void Disparar(GameObject pistola){
    	
		int layerMask = 1 << 8;
        
		layerMask = ~layerMask;
        
        RaycastHit hit;
    	
		if (Input.GetMouseButton(0)){

			if (Physics.Raycast(pistola.transform.position, pistola.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        	{
				Debug.DrawRay(pistola.transform.position, pistola.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
				
				pistola.GetComponent<AudioSource>().Play();

				GameObject _objetoRayCasteado = hit.collider.gameObject;
				
				string _objetoRayCasteadoNombre = _objetoRayCasteado.name;
			
				if(_objetoRayCasteado.CompareTag("GuardSotano") || _objetoRayCasteado.CompareTag("Guards")){
					GameObject.Destroy(_objetoRayCasteado.gameObject);
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

