using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon {

	private int _tiredness;

	public int Tiredness{
		get{	
			return _tiredness;
		}
		set{ 
			_tiredness = value;
		}
	}
}
