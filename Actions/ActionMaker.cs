using UnityEngine;
using System.Collections;
using UnityEngine.AI;
public class ActionMaker : MonoBehaviour
{
	private NavMeshAgent agent;
	private bool isTargetExist;
	private GameObject _target;
	private string _actionType;
	private float healTimer;


	void Start()
	{
<<<<<<< HEAD
		agent = GetComponent<NavMeshAgent> ();
=======
>>>>>>> 0ae5f0d86388174acb0caee9372780532786ddc7
		isTargetExist = false;
	}

	void Update()
	{
		if (isTargetExist)
			CheckDistanceToTarget(_target);
		DecreaseHealTimer ();
<<<<<<< HEAD
=======
			
>>>>>>> 0ae5f0d86388174acb0caee9372780532786ddc7
	}

	public void MakeAction(GameObject target, Vector3 position, string actionType)
	{		
<<<<<<< HEAD
		if (target.tag != "Ground") 
=======
		if (target.tag != "Groud") 
>>>>>>> 0ae5f0d86388174acb0caee9372780532786ddc7
		{
			isTargetExist = true;
			_target = target;
			_actionType = actionType;
		}
		MoveToPosition (position);
	}

	private void MoveToPosition(Vector3 position)
	{
<<<<<<< HEAD
		Debug.Log (position);
=======
		agent = this.gameObject.GetComponent<NavMeshAgent> ();
>>>>>>> 0ae5f0d86388174acb0caee9372780532786ddc7
		agent.SetDestination (position);
	}

	private void CheckDistanceToTarget(GameObject target)
	{
		switch (_actionType)
		{
		case "attack":
			AttackTarget ();
			break;
		case "open":
			OpenChest ();
			break;
		case "heal":
			HealCharacter ();
			break;
		}
			
	}

	private void AttackTarget()
	{
		//if((Vector3.Distance(this.gameObject.transform.position, _target.transform.position)) <= this.gameObject.GetComponent<Human>().CurrentWeapon.Range)
		{
<<<<<<< HEAD
			//agent.Stop();
=======
			agent.Stop();
>>>>>>> 0ae5f0d86388174acb0caee9372780532786ddc7
			_target.GetComponent<Zombie>().BaseHealth -= this.gameObject.GetComponent<Human>().BaseDamage;
		}
	}

	private void OpenChest()
	{
		if((Vector3.Distance(this.gameObject.transform.position, _target.transform.position)) <= 4.0)
		{
<<<<<<< HEAD
			//agent.Stop();
=======
			agent.Stop();
>>>>>>> 0ae5f0d86388174acb0caee9372780532786ddc7
			//ShowBackpack.chosenChest = _target;
		}
	}

	private void HealCharacter()
	{
		if((Vector3.Distance(this.gameObject.transform.position, _target.transform.position)) <= 8.0)
		{
			if (healTimer == 0) 
			{
<<<<<<< HEAD
				//agent.Stop ();
=======
				agent.Stop ();
>>>>>>> 0ae5f0d86388174acb0caee9372780532786ddc7
				//_target.GetComponent<Human> ().BaseHealth += this.gameObject.GetComponent<Human> ().CurrentHealValue;
				healTimer = 90f;
			}
		}
	}

	private void DecreaseHealTimer()
	{
		if (healTimer != 0)
			healTimer -= Time.deltaTime;
	}


}

