//Codigo de animacion de Thomas Tews. Jugador.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

public class ThomasMovementController : MonoBehaviour {

	void Start()
	{
		
	}

	private void Update()
	{
		//ejecuta Las Animaciones del Personaje
		MakeMovement();

	}

	void FixedUpdate()
{
           
}
 

	//Metodo para mover y animar el personaje 
	private void MakeMovement(){
		
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

		
		if (w&&esp) { 
			return;
		}

		//Si no presiona nada.
		if (noKey) {
			return;
		}
		// si presiona la tecla w 
		if (w) {
			PlayerMoveForward();
			return;
		}
		// si presiona la tecla a 
		if (a) {
			return;
		}
		// si presiona la tecla s
		if (s) {
			return;
		}
		// si presiona la tecla d
		if (d) {
			
		}

		// Si aprieta la tecla C
		if(c){
			return;
		}
		if(x){
			return;
		}

		//Acciones con click mouse.
		if (click) {
			return;
		}
		//Cuando hacesclick derecho con el click derecho del mouse.
		if (clickRight) {
			return;
		}
		//Si presiona space
		if (esp) {
			return;
		}
		//Acciones con la tecla E
		if (e) {
			return;
		}





	}


	void PlayerMoveForward(){

		 	//assuming we're only using the single camera:
            var camera = Camera.main;
           
            //Data recieved from CrossPlatformInput Handler:
            float horizontalAxis = CrossPlatformInputManager.GetAxis("Horizontal");
            float verticalAxis = CrossPlatformInputManager.GetAxis("Vertical");
               
            float facing = camera.transform.rotation.y;
            float DistanceFromNeutral = 0;
            float transformZ = 0;
            float transformX = 0;
            float finalZ = 0;
            float finalX = 0;
           
            if (facing > -90 && facing <= 90){ //facing forward
                if(facing >= 0){
                    DistanceFromNeutral = (90 - facing);
                }else{
                    if(facing < 0){
                        DistanceFromNeutral = (90 + facing);
                    };
                };  
                transformX = (1 / 90) * (DistanceFromNeutral);
                transformZ = 90 - transformX;
            };
           
            //for monitoring and debugging:
            Debug.Log("Main Camera's <color=red>Y rotation</color> is <color=red>" + facing + "</color>, and the <color=blue>Distance from Neutral rotation</color> <color=purple>(0/90/180/270)</color> is <color=blue>" + DistanceFromNeutral + "</color>.");
         
            finalX = (transformX * verticalAxis) + (transformZ * horizontalAxis);         
            finalZ = (transformZ * verticalAxis) + (transformX * horizontalAxis);
            transform.Translate((new Vector3( finalX * 0.01f , 0f , finalZ * 0.01f ))* 5f * Time.deltaTime);



	}
		

}

