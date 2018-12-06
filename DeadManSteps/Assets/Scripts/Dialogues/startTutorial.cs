using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startTutorial : MonoBehaviour {

	private void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
				this.GetComponent<DialogueTrigger>().TriggerDialogue();
				Destroy(this.gameObject);
		} 
	}
}
