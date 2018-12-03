using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpItems : MonoBehaviour {

	private void OnTriggerStay(Collider other){
		if (other.tag == "Player") {
			if (Input.GetKey (KeyCode.E)) {
				this.GetComponent<DialogueTrigger>().TriggerDialogue();
				//GameController.hasPhone = true;		
				//Destroy(this.gameObject);
			} 	
		} 
	}

}
