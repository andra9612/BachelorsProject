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
	private float distanceToTarget;
	private float attackTimer;

	void Start()
	{
		agent = GetComponent<NavMeshAgent> ();
		isTargetExist = false;
		attackTimer = GetComponent<Human> ().BaseAttackSpeed;
		healTimer = 0f;
	}

	void Update()
	{
		if (isTargetExist)
			//CheckDistanceToTarget(_target);
			MoveToPosition (_target.transform.position);
		DecreaseTimers ();
	}

	public void MakeAction(GameObject target, Vector3 position, string actionType)
	{		
		if (target.tag != "Ground") 
		{
			_target = target;
			_actionType = actionType;
			SetDistanceToStartAction ();
			isTargetExist = true;
		}
		else
			MoveToPosition (position);
	}

	private void MoveToPosition(Vector3 position)
	{
		agent = this.gameObject.GetComponent<NavMeshAgent> ();
		agent.SetDestination (position);
		if(isTargetExist)
		CheckDistanceToTarget ();
	}
		

	private void SetDistanceToStartAction()
	{
		switch (_actionType)
		{
		case "attack":
			//distanceToTarget = this.gameObject.GetComponent<Human> ().CurrentWeapon.Range;
			break;
		case "open":
			distanceToTarget = 2f;
			break;
		case "heal":
			distanceToTarget = 5f;
			break;
		}

	}

	private void CheckDistanceToTarget()
	{
		if ((Vector3.Distance (this.gameObject.transform.position, _target.transform.position)) <= distanceToTarget) 
		{
			agent.Stop();
			_target.GetComponent<Zombie>().BaseHealth -= this.gameObject.GetComponent<Human>().BaseDamage;
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
	}

	private void AttackTarget()
	{
		if (!IsTargetLeftAttackRange()) 
		{
			agent.Stop();
			//ShowBackpack.chosenChest = _target;
			if (attackTimer == 0) 
			{
				_target.GetComponent<Zombie> ().BaseHealth -= this.gameObject.GetComponent<Human> ().BaseDamage;
				attackTimer = GetComponent<Human> ().BaseAttackSpeed;
			}
		}
	}

	private void OpenChest()
	{
		//ShowBackpack.chosenChest = _target;
	}

	private void HealCharacter()
	{
		if (healTimer == 0) 
		{
			if (healTimer == 0) 
			{
				agent.Stop ();
				//_target.GetComponent<Human> ().BaseHealth += this.gameObject.GetComponent<Human> ().CurrentHealValue;
				healTimer = 90f;
			}
			//_target.GetComponent<Human> ().BaseHealth += this.gameObject.GetComponent<Human> ().CurrentHealValue;
			healTimer = 90f;
		}
	}

	private void DecreaseTimers()
	{
		if (healTimer != 0)
			healTimer -= Time.deltaTime;
		if (attackTimer != 0)
			attackTimer -= Time.deltaTime;
	}

	private bool IsTargetLeftAttackRange()
	{
		if ((Vector3.Distance (this.gameObject.transform.position, _target.transform.position)) > distanceToTarget)
		{
			agent.SetDestination (_target.transform.position);
			return true;
		}
		else
			return false;
	}
}

