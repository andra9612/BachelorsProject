using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon:Item  {
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

	public Weapon(int damage,int range, Texture2D texture, string name, int maxInStack, int nowInStack,int durability,ItemType type)
		:base(texture,name,maxInStack,nowInStack,durability,ItemType.Item)
	{
		Damage = damage;
		Range = range;
	}
}
