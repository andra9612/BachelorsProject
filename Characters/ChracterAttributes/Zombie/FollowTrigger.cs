using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowTrigger : MonoBehaviour {

	private NavMeshAgent agent;
	public List <GameObject> characters;

	void Start () 
	{
		characters = new List<GameObject>();
		agent = this.gameObject.transform.parent.gameObject.GetComponent<NavMeshAgent> ();
	}

	void OnTriggerExit(Collider collider)
	{
		if (collider.CompareTag ("Player")) 
		{
			characters.RemoveAll(c => c.GetInstanceID() == collider.gameObject.GetInstanceID());
			Debug.Log ("deleted" + collider.name);
		}

		if (characters.Count == 0) 
		{
			agent.speed = 2f;
			this.gameObject.transform.parent.gameObject.GetComponent<ZombieMoving> ().isTargetExist = false;
		}
	}

	void Update()
	{
		if (characters.Count != 0) 
		{
			this.gameObject.transform.parent.gameObject.GetComponent<ZombieMoving> ().FindClosestTarget (characters);
		}
	}
		
}
