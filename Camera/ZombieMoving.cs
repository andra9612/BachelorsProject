using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMoving : MonoBehaviour {

	public GameObject zombie;

	NavMeshAgent agent;
	// Use this for initialization
	void Start () {
		agent = zombie.GetComponent<NavMeshAgent> ();
	}
	
	void OnTriggerStay(Collider col){
		if (col.CompareTag ("Player")) {
			Debug.Log ("1");
			agent.SetDestination(col.transform.position);
		}
	}

}
