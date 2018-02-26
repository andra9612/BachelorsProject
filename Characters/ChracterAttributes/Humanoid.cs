using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Humanoid : MonoBehaviour {

	protected int _baseHealth;
	protected int _baseDamage;
	protected int _baseArmor;
	protected float _baseMoveSpeed;
	protected float _baseAttackSpeed;

	public int  BaseHealth {
		get{
			return _baseHealth;
		}
		set{ 
			_baseHealth = value;
			if (_baseHealth <= 0)
				Destroy (gameObject);
		}

	}

	public int  BaseDamage {
		get{
			return _baseDamage;
		}
		set{ 
			_baseDamage = value;
		}

	}

	public int  BaseArmor {
		get{
			return _baseArmor;
		}
		set{ 
			_baseArmor = value;
		}

	}

	public float  BaseMoveSpeed {
		get{
			return _baseMoveSpeed;
		}
		set{ 
			_baseMoveSpeed = value;
		}

	}


	public float  BaseAttackSpeed {
		get{
			return _baseAttackSpeed;
		}
		set{ 
			_baseAttackSpeed = value;
		}

	}

	protected abstract void Initialize ();



}
