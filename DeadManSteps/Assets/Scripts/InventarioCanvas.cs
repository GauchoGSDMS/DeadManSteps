using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioCanvas : MonoBehaviour {

    public GameObject Inventario;

		// void Start ()
  //   {
  //   	Inventario.SetActive(0);
  //   }

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Inventario.SetActive(!Inventario.activeInHierarchy);
        }
	}
}