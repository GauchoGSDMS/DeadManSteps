using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {

	public GameObject destroyedVersion;
	public GameObject lights;
	public GameObject civiles;
	public GameObject alarma;
	private GameObject[] lstGuardsHall;


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
				lights.SetActive(false);
				civiles.SetActive(false);
				alarma.SetActive(true);

				lstGuardsHall = GameObject.FindGameObjectsWithTag("Guards");

				foreach(GameObject guard in lstGuardsHall)
				{
					guard.GetComponent<FieldOfView>().enabled = true;
				}
			}
		 }
    }


}
