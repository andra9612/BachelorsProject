using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour {
	
		private List<GameObject> selectedObjects;
		private GameObject target;
		private bool isHealing;
		private Vector3 position;
			void Start()
			{
				isHealing = false;
			}

			void Update()
			{
			selectedObjects = Camera.main.GetComponent<UnitSelection>().selectedObjects;
				FollowAction();
				FollowHealStatus();							
			}

			void FollowAction()
			{
				if(Input.GetMouseButtonDown(1))
				{
					if(selectedObjects.Count != 0)
					{	
						position = Input.mousePosition;
						Debug.Log (position);
						Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
						RaycastHit hit = new RaycastHit ();
						if(Physics.Raycast(ray, out hit))
						{
							target = hit.collider.gameObject;
						}

						ActionManager.ActionMaker(selectedObjects, target, position, isHealing);
					}
					
				}
			}

			void FollowHealStatus()
			{
				if(Input.GetKey(KeyCode.H))
				{
					isHealing = !isHealing;
				}
			}
}

