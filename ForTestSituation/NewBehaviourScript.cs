using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NewBehaviourScript : MonoBehaviour {

	public GameObject player;
	NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		agent = player.GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp (1)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray,out hit)) {
				agent.SetDestination (hit.point);
			}
		}
	}
}
