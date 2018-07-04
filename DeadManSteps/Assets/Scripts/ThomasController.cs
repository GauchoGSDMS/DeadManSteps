using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThomasController : MonoBehaviour {

    // Private
    private float movHorizontal;
    private float movVertical;
    private Rigidbody rb;
    private bool isGrounded;
    
    public float Speed;
       
    
	// Use this for initialization
	void Start () 
    {
        rb = GetComponent<Rigidbody>();
	}
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            Vector3 jump = new Vector3(movHorizontal,20f,movVertical); // Mejorar esta negrada
            rb.AddForce(jump * Speed); 
            isGrounded = false;
        }        
    }
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        movHorizontal = Input.GetAxis("Horizontal");
        movVertical = Input.GetAxis("Vertical");
        
        Vector3 mov = new Vector3(movHorizontal,0f,movVertical);
        
        transform.Translate(mov * Speed * Time.deltaTime);
	}
    
    void OnCollisionStay(Collision collisioninfo)
    {
        isGrounded = true; // Ver otra cosa sin tags que mejore esto que se procesa todo el tiempo.
    }
        
}
