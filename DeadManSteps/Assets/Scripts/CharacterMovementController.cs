 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.UI;
 public class CharacterMovementController : MonoBehaviour
 {
 
     // En el Inspector incluir referencia al Thomas, que es el que queremos seguir.
	 public Transform Player;
 
     void Start()
     {
 
     }
 
	//Sigue indefinidamente al jugador
     void Update()
     {
		 //Lo mira
         transform.LookAt(Player);
 
		// Si el NPC esta mas lejos que la distancia tolerada , lo sigue indefinidamente a modo NR.
		float distancia = Vector3.Distance(transform.position, Player.position);
         if (distancia <= 5 && distancia >= 2)
         {
 
			 //Accion de moverse en la escena
             transform.position += transform.forward * 3 * Time.deltaTime;
				Debug.Log("Lejos");
			//Deberiamos lanzar una animacion ...
         }else{
			 Debug.Log("Alcance al Inutil");
		 }
     }
 }