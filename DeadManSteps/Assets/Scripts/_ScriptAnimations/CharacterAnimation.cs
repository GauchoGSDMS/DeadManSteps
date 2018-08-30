//Codigo de Animacion de los personajes Principales: Elizabeth, Dimitri, y el Mexicano.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour {

	//El personaje esta hablando.
	[SerializeField] bool talking = false;
	//El personaje esta ejecutando otra animaion
	[SerializeField] bool lockAnimations = false;
	//El personaje esta corriendo.
	[SerializeField] bool running = false;
	[SerializeField] bool idle = true;
	// Use this for initialization

	public Animator m_animator;

	void Start () {
		m_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		PlayAnimations();
	}

	//Metodo para hacer externamente que el personaje corra.
	public void Run(){
		lockAnimations = false;
		idle = false;
		talking = false;
		running = true;
	}

	//Metodo para hacer externamente que el jugador hable.
	void Talk(){
		lockAnimations = false;
		idle = false;
		talking = true;
		running = false;
	}

	//Metodo animacion para hacer hablar al personaje.
	void PlayAnimations(){
		if(running){idle=false; m_animator.Play("Run"); return;}
		if(idle){running=false; m_animator.Play("IdleQuiet"); return;}
		if(talking){StartCoroutine( TalkAnimation() ); return;}
	}

	//Funcion para que el personaje hable.
	private IEnumerator TalkAnimation(){
		lockAnimations = true;
		//indice animacion 1 a 2.	
		m_animator.Play("Talk1");
		yield return new WaitForSeconds (1);
		lockAnimations = false;
	}

}
