using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {

	public GameObject destroyedVersion;

	void Update () {
        if (Input.GetKeyDown("space")) {
	        Instantiate(destroyedVersion, transform.position, transform.rotation);
	        GameObject warning = GameObject.Find ("warning");
	        Destroy(warning.gameObject);
			Destroy(gameObject);
        }
    }


}
