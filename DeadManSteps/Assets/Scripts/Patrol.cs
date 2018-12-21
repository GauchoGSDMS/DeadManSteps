using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {

	public Transform[] patrolPoints;
	public float speed ;
	Transform currentPatrolPoint;
	int currentPatrolIndex;

	void Start () {
		currentPatrolIndex = 0;
		speed = 0.5f;
		currentPatrolPoint = patrolPoints[currentPatrolIndex];
	}
	
	void Update () {
		transform.Translate(Vector3.forward * Time.deltaTime * speed);


		if (Vector3.Distance (transform.position, currentPatrolPoint.position) < .9f) {
			if (currentPatrolIndex + 1 < patrolPoints.Length ) {
				currentPatrolIndex++;
			} else {
				currentPatrolIndex=0;
			}
			currentPatrolPoint = patrolPoints[currentPatrolIndex];

		}

		Vector3 patrolPointDir = currentPatrolPoint.position - transform.position;
		float angle = Mathf.Atan2 (patrolPointDir.x, patrolPointDir.z) * Mathf.Rad2Deg;

		Quaternion q = Quaternion.AngleAxis(angle, Vector3.up);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180f);
		
	}

	private void OnDisable() {
		Destroy(this.gameObject, this.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length+2); 
	}
}
