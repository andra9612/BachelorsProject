using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUpdater : MonoBehaviour {

	private Human currentHuman;

	// Use this for initialization
	void Start () {
		currentHuman = GetComponent<Human> ();
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Input.GetMouseButtonUp (0)) {
			currentHuman.Skills.RecalculateFightingSkill ();
			currentHuman.Show ();
		}*/
	}
}
