using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AggroTrigger : MonoBehaviour {

	private NavMeshAgent agent;


	void Start () {
		agent = this.gameObject.transform.parent.gameObject.GetComponent<NavMeshAgent> ();
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.CompareTag ("Player")) 
		{
			
			this.gameObject.transform.parent.gameObject.GetComponent<ZombieMoving> ().isTargetExist = true;
			this.gameObject.transform.parent.GetChild (1).GetComponent<FollowTrigger> ().characters.Add(collider.gameObject);
		}
	}
		
}
