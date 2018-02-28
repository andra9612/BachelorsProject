using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingHumansAttributes : MonoBehaviour {

	Human currentHuman;
	Rect humanAttributWindow = new Rect(400,50, 230,265);
	bool isOpenAttribute = false;
	// Use this for initialization
	void Start () {
		currentHuman = GameObject.Find ("Player").GetComponent<Human>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyUp (KeyCode.LeftShift))
			isOpenAttribute = !isOpenAttribute;

		if (Input.GetKey(KeyCode.S)) {
			if (Input.GetMouseButtonUp (0)) {
				currentHuman.Stamina -= 10;
			}

			if (Input.GetMouseButtonUp (1)) {
				currentHuman.Stamina += 10;
			}
		}

		if (Input.GetKey(KeyCode.H)) {
			if (Input.GetMouseButtonUp (0)) {
				currentHuman.BaseHealth -= 10;
			}
		}

		if (Input.GetKey(KeyCode.W)) {
			if (Input.GetMouseButtonUp (0)) {
				currentHuman.Skills.RecalculateFightingSkill();
			}
		}
	}

	void OnGUI(){
		if(isOpenAttribute)
			humanAttributWindow = GUI.Window (3, humanAttributWindow,ShowHumanAttributes,"HUMAN ATTRIBUTES");
		else
			humanAttributWindow = new Rect(400,50, 230,265);
	}

	void ShowHumanAttributes(int id){
		GUI.TextField (new Rect(10,20, 200, 20),"BaseHealth: " + currentHuman.BaseHealth.ToString());
		GUI.TextField (new Rect(10,40, 200, 20),"Stamina: " + currentHuman.Stamina.ToString());
		GUI.TextField (new Rect(10,60, 200, 20),"Hunger: " + currentHuman.Hunger.ToString());
		GUI.TextField (new Rect(10,80, 200, 20),"Thirst: " + currentHuman.Thirst.ToString());
		GUI.TextField (new Rect(10,100, 200, 20),"BaseDamage: " + currentHuman.BaseDamage.ToString());
		GUI.TextField (new Rect(10,120, 200, 20),"BaseArmor: " + currentHuman.BaseArmor.ToString());

		GUI.DragWindow ();
	}
}
