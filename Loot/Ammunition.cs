using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammunition : Item {

	private float _ammunitionType;

	public Ammunition(Texture2D texture, string name, int maxInStack, int nowInStack, int  durability,float type)
		:base(texture,name,maxInStack,nowInStack,durability,ItemType.Ammunition)
	{
		AmmunitionType = type;
	}

	public float AmmunitionType{
		get{	
			return _ammunitionType;
		}
		set{ 
			_ammunitionType = value;
		}
	}

	public override void UseItem (Human human)
	{
		if (human.PersonWeapon is RangeWeapon) {
			RangeWeapon weapon = (RangeWeapon)human.PersonWeapon;
			if (weapon.AmmunitionType.AmmunitionType == this.AmmunitionType) {
				int count = weapon.AmmunitionType.NowInStack + this.NowInStack;

				if (weapon.AmmunitionType.MaxInStack <= count) {
					count = weapon.AmmunitionType.MaxInStack - weapon.AmmunitionType.NowInStack;
					this.NowInStack -= count;
					weapon.AmmunitionType.NowInStack = weapon.AmmunitionType.MaxInStack;
				} else {
					weapon.AmmunitionType.NowInStack += this.NowInStack;
					this.NowInStack = 0;
				}
			}
		}
	}

}
