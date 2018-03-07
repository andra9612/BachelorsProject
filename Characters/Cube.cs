using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cube : MonoBehaviour {

	NavMeshAgent agent;

	public GameObject Selected;

	void Start () {
		
		agent = GetComponent<NavMeshAgent>();

	}
	

	void Update () {
		
	}

	public void Move (Vector3 moveToPosition)
	{		
		agent.SetDestination(moveToPosition);
	}

}
