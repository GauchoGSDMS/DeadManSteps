//Codigo de animacion de Thomas Tews. Jugador.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThomasAnimation : MonoBehaviour {

	public Animator m_animator;

	//Estados de las animaciones.

	//El persona esta agachado.
	[SerializeField] bool crouch = false;
	//El personaje esta con otra animacion.
	[SerializeField] bool lockAnimations = false;
	//El personaje Esta Muerto.
	[SerializeField] bool dead = false;
	//El personaje esta recibiendo damage.
	[SerializeField] bool damage = false;

	void Start()
	{
		m_animator = GetComponent<Animator>();
		
	}

	private void Update()
	{
		//Prueba Mistica
		//ejecuta Las Animaciones del Personaje
		PlayAnimations();
		

	}

	//Metodo para mover y animar el personaje 
	private void PlayAnimations(){
		
		//Si estan bloqueadas las animaciones, No hacer Nada.
		if (lockAnimations)	return;

		//Detectar teclas de movimiento
		var noKey = !Input.anyKey; 
		var w = Input.GetKey (KeyCode.W);
		var s = Input.GetKey (KeyCode.S);
		var a = Input.GetKey (KeyCode.A);
		var d = Input.GetKey (KeyCode.D);
		var esp = Input.GetKeyDown (KeyCode.Space);

		//Detectar teclas de acciones
		var click = Input.GetMouseButton (0);
		var clickRight = Input.GetMouseButton(1);
		var e = Input.GetKey (KeyCode.E);
		var c = Input.GetKey (KeyCode.C);
		var x = Input.GetKey (KeyCode.X);

		//Si no presiona nada.
		if (noKey) {
			//Seteo todos los parametros del animator para que el tipo se quede quieto.
			m_animator.SetBool("Forward",false);
			m_animator.SetBool("Backward",false);
			m_animator.SetBool("Right",false);
			m_animator.SetBool("Left",false);
			m_animator.SetBool("Run",false);
			m_animator.SetBool("Jump",false);
			print("NoAprietoNada");
			return;
		}

		// si presiona la tecla w 
		if(w||a||s||d){ 
			//Si se aprieta 
			m_animator.SetBool("Run",true); 
			print("Teclas de Movimiento");
		}
		if (w) {
			m_animator.SetBool("Forward",true);
			print("aprieto a");	
		}
		// si presiona la tecla a 
		if (a) {
			m_animator.SetBool("Left",true);
		}
		// si presiona la tecla s
		if (s) {
			m_animator.SetBool("Backward",true);
		}
		// si presiona la tecla d
		if (d) {
			m_animator.SetBool("Right",true);
		}
		// Si aprieta la tecla C
		if(c){
			m_animator.SetBool("Crouch",true);
		}
		if(x){
			m_animator.SetBool("Crouch",false);
		}

		//Acciones con click mouse.
		if (click) {}
		if (clickRight) {}
		//Si presiona space
		if (esp) {
			m_animator.SetBool("Jump",true);
			m_animator.Play("JumpInPlace");
			StartCoroutine(JumpAnimation());
		}
		//Acciones con la tecla E
		if (e) {
			StartCoroutine(TakeAnimation());
		}
		//Animacion al Morir.
		if (dead) {
			StartCoroutine(DieAnimation());
		}
		//Animacion al recibir Daño.
		if (damage) {
			StartCoroutine(DamageAnimation());
		}

	}
		

	// Corrutina Animacion Saltar 
	private IEnumerator JumpAnimation(){
		yield return new WaitForSeconds(0.7f);
		m_animator.SetBool("Jump",false);
    }

    private IEnumerator JumpForwardAnimation(){
		lockAnimations = true;
		m_animator.Play("Jump");
		yield return new WaitForSeconds (1);
		lockAnimations = false;
    }

    // Corrutina de Animacion Al agarrar un item.
	private IEnumerator TakeAnimation(){
		lockAnimations = true;
		m_animator.Play("Take");
		yield return new WaitForSeconds (1.11f);
		lockAnimations = false;
		m_animator.Play("Idle");
	}

	// Corrutina de Animacion al Morir
	private IEnumerator DieAnimation(){
		lockAnimations = true;
		m_animator.Play("Die");
		yield return new WaitForSeconds (3);
	}

	//Animacion al momento de Recibir un golpe 
	private IEnumerator DamageAnimation(){
		lockAnimations = true;
		m_animator.Play("Damage");
		yield return new WaitForSeconds (1);
		lockAnimations = false;
		m_animator.Play("Idle");
	}

}
