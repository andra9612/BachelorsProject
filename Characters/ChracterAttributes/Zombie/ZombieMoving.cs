using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMoving : MonoBehaviour {

	private NavMeshAgent agent;
	public float timer;
	private float x;
	private float z;
	public bool isTargetExist;
	private Vector3 targetPosition;
	private float distance;
	public Vector3 moveFromPosition;
	public bool isPatrolling;
	public Vector3[] patrollPoints;

	void Start () 
	{
		agent = this.gameObject.GetComponent<NavMeshAgent> ();
		timer = 0.0f;
		isTargetExist = false;
	}
	
	void Update()
	{
		if (!isTargetExist) 
		{
			if (isPatrolling) 
			{
				if(agent.remainingDistance < 0.3f)
					GoToNextPatrollPoint ();
			}
			else 
			{
				RandomMoving ();
				DecreaseMoveTimer ();
			}
		}
	}

	void DecreaseMoveTimer()
	{
		if (timer >= 0.0f)
			timer -= Time.deltaTime;
	}

	private void RandomMoving ()
	{
		if (timer <= 0.0f) 
		{
			timer = Random.Range (3, 10);
			x = Random.Range (50,	300);
			z = Random.Range (50,	300);
			moveFromPosition = transform.position;
			MoveToPoint (new Vector3 (x, 0, z));
		}

	}

	private void GoToNextPatrollPoint()
	{
		int index = Random.Range (0, 50);
		agent.SetDestination (patrollPoints [index]);
	}

	public void MoveToPoint(Vector3 point)
	{
		agent.SetDestination (point);
	}

	public GameObject FindClosestTarget (List<GameObject> characters)
	{
		distance = float.MaxValue;
		GameObject target = null;
		foreach (GameObject go in characters) 
		{
			if (Vector3.Distance (go.transform.position, this.transform.position) < distance) 
			{
				distance = Vector3.Distance (go.transform.position, this.transform.position);
				target = go;
			}
		}
		return target;
	}

}
