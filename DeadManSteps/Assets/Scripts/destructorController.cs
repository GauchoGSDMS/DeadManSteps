using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destructorController : MonoBehaviour {

    void OnCollisionEnter (Collision collision)
    {
        Destroy(collision.gameObject);
        Debug.Break();
    }
}
