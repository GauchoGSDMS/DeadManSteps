using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinDoor : MonoBehaviour {

	private void OnTriggerStay(Collider other) {
		if (other.tag == "Player"){
			Debug.Log("Ganaste");
		}
	}
}
