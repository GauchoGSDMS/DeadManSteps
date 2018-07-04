using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

    private float movX;
    private float movY;
    
	// Update is called once per frame
	void Update () 
    {
        movX = Input.GetAxis("Mouse X");
        movY = Input.GetAxis("Mouse Y");
        
        transform.Rotate(-movY,movX,0);
	}
}
