using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon {

	private int _tiredness;

	public MeleeWeapon (Texture2D texture, string name, int maxInStack, int nowInStack,
	                   int  durability, ItemType itemType, int damage, int range, int tiredness)
		:base(damage,range,texture,name,maxInStack,nowInStack,durability, ItemType.RangeWeapon)
	{
		Tiredness = tiredness;
	}

	public override void UseItem (Human human)
	{
		Debug.Log ("Use melee weapon");
		human.PersonWeapon = this;
		NowInStack--;
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
