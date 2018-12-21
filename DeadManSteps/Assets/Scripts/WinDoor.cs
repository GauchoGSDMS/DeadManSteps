using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinDoor : MonoBehaviour {

	public GameObject winScreen;
	
	private void OnTriggerStay(Collider other) {
		if (other.tag == "Player"){
			winScreen.SetActive(true);
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}
}
