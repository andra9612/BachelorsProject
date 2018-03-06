using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowTrigger : MonoBehaviour {

	private NavMeshAgent agent;
	public List <GameObject> characters;
	private float distance;
	private Vector3 targetPosition;

	void Start () 
	{
		agent = this.gameObject.transform.parent.gameObject.GetComponent<NavMeshAgent> ();
		distance = 0f;
	}

	void OnTriggerExit(Collider collider)
	{
		if (collider.CompareTag ("Player")) 
		{
			characters.RemoveAll(c => c.GetInstanceID() == collider.gameObject.GetInstanceID());
		}

		if (characters.Count == 0) 
		{
			this.gameObject.transform.parent.gameObject.GetComponent<ZombieMoving> ().isTargetExist = false;
		}
	}

	void Update()
	{
		
		if(characters.Count != 0)
			FindClosestTarget ();
	}

	void FindClosestTarget ()
	{
		Debug.Log (characters[0].name);
		foreach (GameObject go in characters) 
		{
			if (Vector3.Distance (go.transform.position, this.transform.position) < distance) 
			{
				distance = Vector3.Distance (go.transform.position, this.transform.position);
				targetPosition = go.transform.position;
			}
		}
		MoveToTarget ();
	}

	void MoveToTarget()
	{
		agent.SetDestination (targetPosition);
	}
}
