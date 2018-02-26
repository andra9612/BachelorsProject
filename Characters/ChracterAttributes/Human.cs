using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Humanoid {

	private HumanSkills _skills;

	private int startDamage;

	private bool isTired = false;

	private int _hunger;
	private int _thirst;
	private int _stamina;


	private const float needsCD = 180f;
	private float hungerAndThirstyTime = needsCD;

	 void Start(){
		Initialize ();
	}

	void Update(){
		CalculateNeedsTime ();
	}

	protected override void Initialize ()
	{
		BaseHealth = 100;
		BaseDamage = 10;
		BaseArmor = 0;
		BaseMoveSpeed = 8f;
		BaseAttackSpeed = 5f;
		Stamina = 100;
		Hunger = 100;
		Thirst = 100;

		_skills = new HumanSkills (this);
	}

	private void CalculateNeedsTime(){
		if (hungerAndThirstyTime >= 0)
			hungerAndThirstyTime -= Time.deltaTime;
		else {
			DecremenNeeds ();
		}

		Debug.Log (hungerAndThirstyTime);
	}


	private void DecremenNeeds(){
		Hunger -= 10;
		Thirst -= 10;
		hungerAndThirstyTime = needsCD;
		Show ();
	}

	public HumanSkills Skills{
		get{ 
			return _skills;
		}
		set{ 
			_skills = value;
		}
	}

	public int Hunger{
		get{ 
			return _hunger;
		}
		set{ 
			
			_hunger = value;

			if (_hunger < 0) {
				_hunger = 0;
				BaseHealth -= 5;
			}


			if (_hunger > 100)
				_hunger = 100;
		}
	}

	public int Thirst{
		get{ 
			return _thirst;
		}
		set{ 

			_thirst = value;

			if (_thirst < 0){
				_thirst = 0;
				BaseHealth -= 5;
			}

			if (_thirst > 100)
				_thirst = 100;
		}
	}

	public int Stamina{
		get{ 
			return _stamina;
		}

		set{ 
			_stamina = value;
			if (_stamina  <= 100 && _stamina >=0) {
				if (_stamina <= 40  && isTired == false) {
					isTired = true;
					startDamage = BaseDamage;
					BaseDamage -= (int)(BaseDamage / 2);
				} else if (BaseDamage != startDamage && isTired ==  true && _stamina > 40) {
					BaseDamage = (int)(BaseDamage * 2);
					isTired = false;
				}
			} else {

				if (_stamina < 0) {
					_stamina = 0;
					Debug.Log ("Stamina is empty");
				}
				if (_stamina > 100) {
					_stamina = 100;
					Debug.Log ("Stamina is full");
				}
			}

		}
	}

	public void Show (){
		Debug.Log ("************************************************");
		Debug.Log ("BaseHealth:" + BaseHealth);
		Debug.Log ("Stamina:" + Stamina);
		Debug.Log ("Hunger:" + Hunger);
		Debug.Log ("Thirst:" + Thirst);
		Debug.Log ("BaseDamage:" + BaseDamage);
		Debug.Log ("BaseArmor:" + BaseArmor);
		Debug.Log ("************************************************");
	}

}
