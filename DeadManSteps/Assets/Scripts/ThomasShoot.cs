using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThomasShoot : MonoBehaviour
{
	public GameObject pistola;
	private int _cantDisparos;
	private float tiempoEntreDisparos ;
	private float ultimaVezDisparado;
	public Animator m_Animator;

	void Start() 
	{
		_cantDisparos = 5;
		tiempoEntreDisparos = 1;
		ultimaVezDisparado = Time.time;
	}

    void Update()
    {    
    	pistola.SetActive(false);
        
		//Clickeando mouse apuntar.
		if (Input.GetMouseButton(1)){
			
			//Controla la camara rotando al pj con el mouse.
			float mousex = Input.GetAxis ("Mouse X");
			if(mousex!=0){
				ThomasMovementController.Instance.transform.Rotate(0, mousex*1.5f*Time.deltaTime, 0);
			}
			m_Animator.Play("PistolAim");
			pistola.SetActive(true);

			//Funcion para disparar. Si supera el cooldowns
			if(Time.time - ultimaVezDisparado > tiempoEntreDisparos){
				Disparar();	
				m_Animator.Play("Shooting");	
			}

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
	            Debug.DrawRay(pistola.transform.position, pistola.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
				GameObject _objetoRayCasteado = hit.collider.gameObject;
				string _objetoRayCasteadoNombre = _objetoRayCasteado.name;
            	if( _listaDePuedoMatar.Contains(_objetoRayCasteadoNombre) ){
					_objetoRayCasteado.GetComponent<Animator>().SetBool("isDead",true);
				}

				Debug.Log("Hice 1 disparo");
				

        	}
        	else
        	{
				//Si el raycast pega en el infinito, dibujar una linea blanca...
	            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            	Debug.Log("Did not Hit");
        	}

		}

		
    }

	IEnumerator ShootingAnimation(Animator anim){
		anim.Play("ShootingAnimation");	
		yield return new WaitForSeconds(1);
	}

	

}	