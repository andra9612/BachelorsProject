﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ActionManager {
	
	static string _actionType;

	public static void ActionMaker(List<Human> selectedObjects, GameObject target, Vector3 position, bool isHeal)
	{		
		switch (target.tag) 
		{
			default:
				_actionType = "move";
				break;
			case "Zombie":
				_actionType = "attack";
				break;
			case "Chest":
				_actionType = "open";
				break;
			case "Human":
				if(isHeal)
					_actionType = "heal";
				else
					_actionType = "move";
			break;
		}

		foreach (Human go in selectedObjects) 
		{
			go.GetComponent<ActionMaker>().MakeAction(target, position, _actionType);
		}
	}
}
