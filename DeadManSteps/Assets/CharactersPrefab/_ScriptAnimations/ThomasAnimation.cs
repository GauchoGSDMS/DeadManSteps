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
		var wa = w && a;
		var wd = w && d;
		var sa = s && a;
		var sd = s && d;

		//Detectar teclas de acciones
		var click = Input.GetMouseButton (0);
		var clickRight = Input.GetMouseButton(1);
		var e = Input.GetKey (KeyCode.E);
		var c = Input.GetKey (KeyCode.C);
		var x = Input.GetKey (KeyCode.X);

		//Si no presiona nada.
		if (noKey&&crouch) {m_animator.Play ("CrouchIdle");return;}
		//Si presiona S y A
		if (sa&&crouch) {return;}
		//Si presiona S y D
		if (sd&&crouch) {return;}
		// si presiona la tecla w y a 
		if (wa&&crouch) {return;}
		// si presiona la tecla w y d
		if (wd&&crouch) {return;}
		// si presiona la tecla w 
		if (w&&crouch) {m_animator.Play ("CrouchForward");return;}
		// si presiona la tecla a 
		if (a&&crouch) {m_animator.Play ("CrouchLeft");return;}
		// si presiona la tecla s
		if (s&&crouch) {m_animator.Play ("CrouchBack");return;}
		// si presiona la tecla d
		if (d&&crouch) {m_animator.Play ("CrouchRight");return;}


		if (w&&esp) { StartCoroutine( JumpForwardAnimation() );return;}

		//Si no presiona nada.
		if (noKey) {m_animator.Play ("Idle");return;}
		//Si presiona S y A
		if (sa) {m_animator.Play ("Back");return;}
		//Si presiona S y D
		if (sd) {m_animator.Play ("Back");return;}
		// si presiona la tecla w y a 
		if (wa) {m_animator.Play ("Run");return;}
		// si presiona la tecla w y d
		if (wd) {m_animator.Play ("Run");return;}
		// si presiona la tecla w 
		if (w) {m_animator.Play ("Run");return;}
		// si presiona la tecla a 
		if (a) {m_animator.Play ("Left");return;}
		// si presiona la tecla s
		if (s) {m_animator.Play ("Back");return;}
		// si presiona la tecla d
		if (d) {m_animator.Play ("Right");return;}

		// Si aprieta la tecla C
		if(c){crouch = true;return;}
		if(x){crouch = false; return;}

		//Acciones con click mouse.
		if (click) {m_animator.Play ("Shooting");return;}
		if (clickRight) {m_animator.Play ("PistolAim");return;}
		//Si presiona space
		if (esp) { StartCoroutine( JumpAnimation()); return; }
		//Acciones con la tecla E
		if (e) {StartCoroutine( TakeAnimation() );return;}
		//Animacion al Morir.
		if (dead) { StartCoroutine( DieAnimation() ); return;}
		//Animacion al recibir Daño.
		if (damage) {StartCoroutine( DamageAnimation() );return;}




	}
		

	// Corrutina Animacion Saltar 
	private IEnumerator JumpAnimation(){
		lockAnimations = true;
		m_animator.Play("JumpInPlace");
		yield return new WaitForSeconds (1);
		lockAnimations = false;
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
	}

}
