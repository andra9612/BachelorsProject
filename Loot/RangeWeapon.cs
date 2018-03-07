using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : Weapon {

	private int _ammunition;
	private float _ammunitionType;


	public RangeWeapon(Texture2D texture, string name, int maxInStack, int nowInStack,
		int  durability, ItemType itemType, int damage,int range,int ammunition, float ammunitionType)
		:base(damage,range,texture,name,maxInStack,nowInStack,durability, ItemType.RangeWeapon)
	{
		Ammunition = ammunition;
		AmmunitionType = ammunitionType;
	}


	public override void UseItem (Human human)
	{
		Debug.Log ("Use range weapon");
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
