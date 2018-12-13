using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldOfView : MonoBehaviour {

	public float viewRadius;
	[Range(0,360)]
	public float viewAngle;

	public LayerMask targetMask;
	public LayerMask obstacleMask;
	private Patrol patrol;
	private Animator anim;

	[HideInInspector]
	public List<Transform> visibleTargets = new List<Transform>();

	void Start() {
		StartCoroutine ("FindTargetsWithDelay", .2f);
		viewAngle = 190f;
		viewRadius = 20f;
		patrol = GetComponent<Patrol>();
		anim = GetComponent<Animator>();
	}


	IEnumerator FindTargetsWithDelay(float delay) {
		while (true) {
			yield return new WaitForSeconds (delay);
			FindVisibleTargets ();
		}
	}

	void FindVisibleTargets() {
		visibleTargets.Clear ();
		Collider[] targetsInViewRadius = Physics.OverlapSphere (transform.position, viewRadius, targetMask);

		for (int i = 0; i < targetsInViewRadius.Length; i++) {
			if (targetsInViewRadius [i].name == "Thomas") {
				Transform target = targetsInViewRadius [i].transform;				
				Vector3 dirToTarget = (target.position - transform.position).normalized;
				float dstToTarget = Vector3.Distance (transform.position, target.position);

				if (Vector3.Angle (transform.forward, dirToTarget) < viewAngle / 2 && checkIfInside(dirToTarget, dstToTarget)) {

				/* esto lo hago para que el guardia gire mirando a Thomas */
					Vector3 patrolPointDir = target.position - transform.position;
					float angle = Mathf.Atan2 (patrolPointDir.x, patrolPointDir.z) * Mathf.Rad2Deg;
					patrol.speed = 0f;

					Quaternion q = Quaternion.AngleAxis(angle, Vector3.up);
					transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180f);

					/********************************************************************/

					if (Vector3.Distance (transform.position, target.position) < 5f) { /* si Thomas esta a menos de 5, lo empieza a seguir*/
						
						patrol.enabled = false;
						patrol.speed = 1.5f;
						anim.SetBool("isRunning",true);

						if (!Physics.Raycast (transform.position, dirToTarget, dstToTarget, obstacleMask)) {
							transform.position = Vector3.MoveTowards(transform.position, target.position, 3 * Time.deltaTime);
							visibleTargets.Add (target);

						}

					} else {
						patrol.enabled = false;
					}
				}
			} else {
				patrol.enabled = true;
				patrol.speed = 0.5f;
				anim.SetBool("isRunning",false);
			}
		}
	}


	public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal) {
		if (!angleIsGlobal) {
			angleInDegrees += transform.eulerAngles.y;
		}
		return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad),0,Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
	}

/* este metodo chequea si Thomas esta a la vista de los guardias. Basicamente tira un raycast con alcance maximo a la posicion
 donde esta Thomas y busca el primer hit. Si ese hit es vacio o el nombre del objeto no es Thomas, entonces Thomas esta a la vista.*/

	bool checkIfInside(Vector3 dirToTarget, float targetdst) {

		RaycastHit[] hits;
		hits = Physics.RaycastAll(transform.position, dirToTarget, targetdst);
		//float walldst = Vector3.Distance (transform.position, hitInfo.transform.position);

		if (hits.Length > 0) {
			if (hits[0].transform.name != "Thomas") {
				return false;
			} 		
		}

		return true;
	}
}
