using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpItems : MonoBehaviour {

	private void OnTriggerStay(Collider other){
		if (other.tag == "Player") {
			if (Input.GetKey (KeyCode.E)) {
				other.GetComponent<Animator>().SetBool("isTalkingPhone",true);
				this.GetComponent<DialogueTrigger>().TriggerDialogue();
				this.GetComponent<AudioSource>().volume = 0;
				Destroy(this.gameObject);
			} 	
		} 
	}

}
