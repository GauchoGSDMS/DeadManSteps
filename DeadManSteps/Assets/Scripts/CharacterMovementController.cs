 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.UI;
 public class CharacterMovementController : MonoBehaviour
 {
 
     // En el Inspector incluir referencia al Thomas, que es el que queremos seguir.
	 public Transform Player;
     int MoveSpeed = 4;
     int MaxDist = 5;
     int MinDist = 2;
 
     void Start()
     {
 
     }
 
	//Sigue indefinidamente al jugador
     void Update()
     {
		 //Lo mira
         transform.LookAt(Player);
 
		// Si el NPC esta mas lejos que la distancia tolerada , lo sigue indefinidamente a modo NR.
         if (Vector3.Distance(transform.position, Player.position) >= MinDist)
         {
 
			 //Accion de moverse en la escena
             transform.position += transform.forward * MoveSpeed * Time.deltaTime;

			//Deberiamos lanzar una animacion ...
 
 
             if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
             {
                 //Aca debe incluirse acciones, ejemplo Disparar o pegar con un palo, cuando alcanza al jugador.
             }
 
         }
     }
 }