using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distraction : MonoBehaviour 
{
	private Rigidbody rb;
	private Collider sc;

	void Start() 
	{
		rb = this.GetComponent<Rigidbody>();
		sc = this.GetComponent<SphereCollider>();	
	}

	void OnTriggerStay(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			if(Input.GetKey(KeyCode.E))
			{
				rb.AddForce(new Vector3(0,30f,-40f));
				GameController.isDistractionOk = true;
			}
		}
	}
	
	
}
