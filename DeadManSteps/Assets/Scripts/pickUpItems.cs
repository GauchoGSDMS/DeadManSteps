using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpItems : MonoBehaviour {

	private GameObject[] lstGuards;
	public GameObject imgAmulet; 

	private void OnTriggerStay(Collider other){
		if (other.tag == "Player") {
			if (Input.GetKey (KeyCode.E)) {
				if(GameController.isAmuletAlive)
				{
					ImAmulet();
				}else if(GameController.isDistractionOk)
				{
					CheckWhoIAM();
				}
				
				other.GetComponent<Animator>().SetBool("isTalkingPhone",true);
				this.GetComponent<DialogueTrigger>().TriggerDialogue();
				this.GetComponent<AudioSource>().volume = 0;
				
				TryForce();
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

	void TryForce()
	{
		this.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,50f));
	}

	void ImAmulet()
	{
		if(GameController.isDistractionOk)
		{
			GameController.isAmuletAlive = false;
			imgAmulet.SetActive(true);
			Destroy(this.gameObject);
		}
		else
		{
			Debug.Log("Debes distraer a los gaurdias antes de agarrar el amuleto");
		}
	}

}
