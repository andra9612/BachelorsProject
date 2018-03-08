using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : Weapon {

	private int _ammunition;
	private Ammunition _ammunitionType;


	public RangeWeapon(Texture2D texture, string name, int maxInStack, int nowInStack,
		int  durability, ItemType itemType, int damage,int range,int ammunition, Ammunition ammunitionType)
		:base(damage,range,texture,name,maxInStack,nowInStack,durability, ItemType.RangeWeapon)
	{
		Clip = ammunition;
		AmmunitionType = ammunitionType;
	}


	public override void UseItem (Human human)
	{
		Debug.Log ("Use range weapon");
		human.PersonWeapon = this;
		NowInStack--;
	}

	public int Clip{
		get{	
			return _ammunition;
		}
		set{ 
			_ammunition = value;
		}
	}

	public Ammunition AmmunitionType{
		get{	
			return _ammunitionType;
		}
		set{ 
			_ammunitionType = value;
		}
	}
}
