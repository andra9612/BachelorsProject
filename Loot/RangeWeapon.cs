using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : Weapon {

	private int _ammunition;
	private float _ammunitionType;

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
