using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollideAndAttackTrigger : MonoBehaviour {

	private float attackTimer;
	private bool isTargetInAttackRange;

	void Start()
	{
		attackTimer = 0f;
	}

	void Update()
	{
		if (isTargetInAttackRange)
			DecreaseAttackTimer ();
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.CompareTag ("Wall")) 
		{
			isTargetInAttackRange = true;
			this.gameObject.GetComponent<ZombieMoving> ().timer = -1.0f;
		}
			
	}

	void OnTriggerStay(Collider collider)
	{
		if (collider.CompareTag ("Player")) 
		{
			if (attackTimer == 0) 
			{
				collider.gameObject.GetComponent<Human> ().BaseHealth -= this.gameObject.transform.parent.gameObject.GetComponent<Zombie> ().BaseDamage;
				attackTimer = this.gameObject.transform.parent.gameObject.GetComponent<Zombie> ().BaseAttackSpeed;
			}
				
		}

	}

	private void DecreaseAttackTimer()
	{
		if (attackTimer != 0)
			attackTimer -= Time.deltaTime;
	}

}
