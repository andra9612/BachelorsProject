using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WallCollideAndAttackTrigger : MonoBehaviour {

	private float attackTimer;
	private List<GameObject> attackableTargets;
	private float distance;
	private GameObject target;
	private NavMeshAgent agent;

	void Start()
	{
		attackTimer = 0f;
		attackableTargets = new List<GameObject> ();
		agent = this.gameObject.transform.parent.gameObject.GetComponent<NavMeshAgent> ();
	}

	void Update()
	{
		if (attackableTargets.Count != 0)
			AttackClosestTarget ();
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.CompareTag ("Wall")) 
		{			
			GetComponent<ZombieMoving> ().MoveToPoint (GetComponent<ZombieMoving> ().moveFromPosition);
		}
		if (collider.CompareTag ("Player")) 
		{
			agent.Stop();
			transform.parent.GetComponent<FollowTrigger> ().isAttacking = true;
			attackableTargets.Add (collider.gameObject);
		}
			
	}

	void OnTriggerExit(Collider collider)
	{
		if (collider.CompareTag ("Player")) 
		{
			attackableTargets.RemoveAll(c => c.GetInstanceID() == collider.gameObject.GetInstanceID());
			if(attackableTargets.Count == 0)
				transform.parent.GetComponent<FollowTrigger> ().isAttacking = false;	
		}
	}

	private void AttackClosestTarget ()
	{
		if (attackTimer == 0)
		{
			target = this.gameObject.transform.parent.gameObject.GetComponent<ZombieMoving> ().FindClosestTarget (attackableTargets);
			target.GetComponent<Human> ().BaseHealth -= this.gameObject.transform.parent.gameObject.GetComponent<Zombie> ().BaseDamage;
			attackTimer = this.gameObject.transform.parent.gameObject.GetComponent<Zombie> ().BaseAttackSpeed;
			Debug.Log ("attacking " + target.name);
		}

	}
		

	private void DecreaseAttackTimer()
	{
		if (attackTimer != 0)
			attackTimer -= Time.deltaTime;
	}

}
