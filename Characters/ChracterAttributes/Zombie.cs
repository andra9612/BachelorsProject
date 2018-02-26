using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Humanoid {

	void Start(){
		Initialize ();
	}

	protected override void Initialize ()
	{
		BaseHealth = 100;
		BaseDamage = 10;
		BaseArmor = 0;
		BaseMoveSpeed = 5f;
		BaseAttackSpeed = 3f;
	}

}
