using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thomas : Player 
{

	private Animator animator;
	
	void Awake()
	{
		animator = this.GetComponent<Animator>();
	}

	void OnTriggerStay(Collider other)
	{
		if(Input.GetKey(KeyCode.E))
		{
			Debug.Log(other.gameObject);
			if (other.gameObject.CompareTag("PickUp"))
			{
				Debug.Log("Entre Aca");	
				ThomasMovementController.Instance.anim.SetTrigger("isTakingObj");
				ThomasMovementController.Instance.anim.SetBool("isTaking",true);
				other.gameObject.SetActive(false);

			}
		}
	}

	void LateUpdate()
	{
		if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
		{
			ThomasMovementController.Instance.anim.SetBool("isTaking",false);
		}
	}
}
