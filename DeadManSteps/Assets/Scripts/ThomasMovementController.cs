//Codigo de animacion de Thomas Tews. Jugador.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThomasMovementController : MonoBehaviour {


	private InputHandler inputHandler;
	public Animator anim;
	public GameObject pistol;
	public static ThomasMovementController Instance {get; private set;}
	public bool disparando = false;

	//1° Declarar un Singleton Acá -- Y ponerle el animator publico y estatico. 

	private	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	void Start()
	{
		inputHandler = new InputHandler();
		anim = this.GetComponent<Animator>();
	}

	private void Update()
	{
		if (inputHandler.HandleInput() != null)
		{
			Command cmd = inputHandler.HandleInput(); // Me devuelve que commando se va a ejecutar
			cmd.Execute(this.gameObject,anim); //Ejecuta el comando especifico,aca podria ir cualquier cosa, siempre y cuando matchee con algun comando. 
		}	

		if (Input.GetMouseButton(0)&&Input.GetMouseButton(1)&& disparando==false){
			disparando = true;
			GetComponent<AudioSource>().Play();
			StartCoroutine("Shooting");
		}
	
	}

	 IEnumerator Shooting() {
		 anim.Play("PistolShooting");
		
		 GameObject pistol1 = pistol;
		 pistol.transform.Translate(new Vector3(0,-.2f,.2f));
		 pistol.transform.Rotate(-10,0,0);
		 yield return new WaitForSeconds(0.1f);
		 pistol.transform.Rotate(10,0,0);
         yield return new WaitForSeconds(0.5f);
		 pistol.transform.Translate(new Vector3(0,.2f,-.2f));
		 disparando = false;
     }
 
}

