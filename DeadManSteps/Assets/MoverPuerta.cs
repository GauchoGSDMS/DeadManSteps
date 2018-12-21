using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPuerta : MonoBehaviour {



	private void OnTriggerStay(Collider other) {
		if(other.gameObject.CompareTag("Player"))
		{
			if(Input.GetKey(KeyCode.E))
			{				
				
				this.transform.Translate(new Vector3(1f,0,0));
				//this.transform.rotation = Quaternion.Euler(0,90,180);
			}
		}
	}
	
}
