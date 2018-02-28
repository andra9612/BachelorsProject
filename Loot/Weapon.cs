using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon:Item  {
	private int _damage;
	private int _range;


	public int Damage{
		get{	
			return _damage;
		}
		set{ 
			_damage = value;
		}
	}

	public int Range{
		get{	
			return _range;
		}
		set{ 
			_range = value;
		}
	}
}
