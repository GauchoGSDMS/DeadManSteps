using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookX : MonoBehaviour 
{	
	[SerializeField]
	private float sensitivity = 5f;

	void Update () 
	{
		float mouseX = Input.GetAxis("Mouse X");
		transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + (mouseX * sensitivity), transform.localEulerAngles.z);
	}
}
