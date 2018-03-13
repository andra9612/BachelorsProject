using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollideTrigger : MonoBehaviour {

	private float attackTimer;
	private List<GameObject> attackableTargets;
	private float distance;
	private GameObject target;

	void Start()
	{
		attackTimer = 0f;
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
			this.gameObject.GetComponent<ZombieMoving> ().timer = -1.0f;
			attackableTargets.Add (collider.gameObject);
		}
			
	}

	void OnTriggerExit(Collider collider)
	{
		if (collider.CompareTag ("Player")) 
		{
			attackableTargets.RemoveAll(c => c.GetInstanceID() == collider.gameObject.GetInstanceID());
		}
	}

	private void AttackClosestTarget ()
	{
		

		if (attackTimer == 0)
		{
			distance = float.MaxValue;
			foreach (GameObject go in attackableTargets) 
			{
				if (Vector3.Distance (go.transform.position, this.transform.position) < distance) 
				{
					distance = Vector3.Distance (go.transform.position, this.transform.position);
					target = go;
				}
			}
			target.GetComponent<Human> ().BaseHealth -= this.gameObject.transform.parent.gameObject.GetComponent<Zombie> ().BaseDamage;
			attackTimer = this.gameObject.transform.parent.gameObject.GetComponent<Zombie> ().BaseAttackSpeed;
		}

	}
		

	private void DecreaseAttackTimer()
	{
		if (attackTimer != 0)
			attackTimer -= Time.deltaTime;
	}

}
