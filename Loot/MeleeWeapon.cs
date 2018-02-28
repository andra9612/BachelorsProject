using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon {

	private int _tiredness;

	public MeleeWeapon(Texture2D texture, string name, int maxInStack, int nowInStack,
		int  durability, ItemType itemType, int damage,int range,int tiredness){
		ItemTexture = texture;
		ItemName = name;
		MaxInStack = maxInStack;
		NowInStack = nowInStack;
		Durability = durability;
		Type = itemType;
		Damage = damage;
		Range = range;
		Tiredness = tiredness;
	}

	public int Tiredness{
		get{	
			return _tiredness;
		}
		set{ 
			_tiredness = value;
		}
	}
}
