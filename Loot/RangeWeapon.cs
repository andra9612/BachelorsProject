using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : Weapon {

	private int _ammunition;
	private float _ammunitionType;


	public RangeWeapon(Texture2D texture, string name, int maxInStack, int nowInStack,
		int  durability, ItemType itemType, int damage,int range,int ammunition, float ammunitionType){
		ItemTexture = texture;
		ItemName = name;
		MaxInStack = maxInStack;
		NowInStack = nowInStack;
		Durability = durability;
		Type = itemType;
		Damage = damage;
		Range = range;
		Ammunition = ammunition;
		AmmunitionType = ammunitionType;
	}
	public int Ammunition{
		get{	
			return _ammunition;
		}
		set{ 
			_ammunition = value;
		}
	}

	public float AmmunitionType{
		get{	
			return _ammunitionType;
		}
		set{ 
			_ammunitionType = value;
		}
	}
}
