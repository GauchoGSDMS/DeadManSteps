using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpItems : MonoBehaviour {

	private DialogueTrigger script;

	private void Start() {
		script = this.GetComponent<DialogueTrigger>();
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player") 
		{
			if (Input.GetKey (KeyCode.E)) {
				script.TriggerDialogue();
			} 	
		} 
	}
}
