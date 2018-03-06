﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMoving : MonoBehaviour {

	private NavMeshAgent agent;
	public float timer;
	private float x;
	private float z;
	public bool isTargetExist;

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
			DecreaseMoveTimer ();
			IsTimerEnded ();
		}
	}

	void DecreaseMoveTimer()
	{
		if (timer >= 0.0f)
			timer -= Time.deltaTime;
	}

	void IsTimerEnded ()
	{
		if (timer <= 0.0f) 
		{
			timer = Random.Range (3, 10);
			x = Random.Range (50,	300);
			z = Random.Range (50,	300);
			Debug.Log (timer + "  " + x + "  " + z);
			MoveToPoint ();
		}

	}

	void MoveToPoint()
	{
		agent.SetDestination (new Vector3 (x, 0, z));
	}		

}