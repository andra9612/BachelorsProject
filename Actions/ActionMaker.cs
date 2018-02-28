using UnityEngine;
using System.Collections;
using UnityEngine.AI;
public class ActionMaker : MonoBehaviour
{
	NavMeshAgent agent;
	public void MakeAction(GameObject target, Vector3 position, string actionType)
	{
		switch(actionType)
		{
		case "move":
			Debug.Log (this.gameObject.transform.position);
				agent = this.gameObject.GetComponent<NavMeshAgent> ();
				agent.SetDestination (position);
				break;
		}
	}
}

