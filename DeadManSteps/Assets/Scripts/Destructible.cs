using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {

	public GameObject destroyedVersion;
	private GameObject[] lstLights;


	void OnTriggerStay(Collider other)
	 {
		 if (other.gameObject.CompareTag("Player"))
		 {
			if (Input.GetKeyDown(KeyCode.E)) 
			{
				Instantiate(destroyedVersion, transform.position, transform.rotation);
				GameObject warning = GameObject.Find ("warning");
				Destroy(warning.gameObject);
				Destroy(gameObject);
				GameObject fire = GameObject.Find("Particle System");
				Vector3 temp = new Vector3(0,-2f,0);
				fire.transform.position += temp ;
				
				lstLights = GameObject.FindGameObjectsWithTag("MuseumLights");

				foreach(GameObject light in lstLights )
				{
					light.SetActive(false);
				}


			}
		 }
    }


}
