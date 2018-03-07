using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSkills{

	private Human currentHuman;

	private int _fightingSkill;
	private int _curing;
	private int _crafting;

	public HumanSkills(Human human){
		_fightingSkill = 1;
		_curing = 1;
		_crafting = 1;
		currentHuman = human;
	}

	public void RecalculateFightingSkill(){
		_fightingSkill += 1;
		currentHuman.BaseHealth += _fightingSkill * 10;
		currentHuman.BaseDamage += _fightingSkill * 2 ;
		currentHuman.BaseArmor += _fightingSkill + 5;
//		currentHuman.MaxStamina += 10;
	}

	public void RecalculateCrafting(){
		_crafting += 1;
		/**/
	}

	public void RecalculateCuring(){
		_curing += 1;
		/**/
	}

	public int FightingSkill{
		get{ 
			return _fightingSkill;
		}
		set{ 
			_fightingSkill = value;
		}
	}

	public int Curing{
		get{ 
			return _curing;
		}
		set{ 
			_curing = value;
		}
	}

	public int Crafting{
		get{ 
			return _crafting;
		}
		set{ 
			_crafting = value;
		}
	}


}
