using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpItems : MonoBehaviour {

	private GameObject[] lstGuards;

	private void OnTriggerStay(Collider other){
		if (other.tag == "Player") {
			if (Input.GetKey (KeyCode.E)) {
				other.GetComponent<Animator>().SetBool("isTalkingPhone",true);
				this.GetComponent<DialogueTrigger>().TriggerDialogue();
				this.GetComponent<AudioSource>().volume = 0;
				//other.GetComponent<Animator>().SetBool("isTalkingPhone",true);
//				this.GetComponent<DialogueTrigger>().TriggerDialogue();
//				this.GetComponent<AudioSource>().volume = 0;
				CheckWhoIAM();
				Destroy(this.gameObject);
			} 	
		} 
	}

	void CheckWhoIAM()
	{
		if (GameController.isAmuletAlive)
		{
			if(lstGuards == null)
			{
				lstGuards = GameObject.FindGameObjectsWithTag("Guards");
				
				foreach (GameObject guard in lstGuards)
				{
					// Funciona viejahhh!  Persigue a Thomas. 
					guard.GetComponent<FieldOfView>().enabled = true;
				}

			}

			GameController.isAmuletAlive = false;	
		}
		
	}

}
