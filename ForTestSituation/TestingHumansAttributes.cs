using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingHumansAttributes : MonoBehaviour {

	Human currentHuman;
	// Use this for initialization
	void Start () {
		currentHuman = GameObject.Find ("Player").GetComponent<Human>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.S)) {
			if (Input.GetMouseButtonUp (0)) {
				currentHuman.Stamina -= 10;
				currentHuman.Show ();
			}

			if (Input.GetMouseButtonUp (1)) {
				currentHuman.Stamina += 10;
				currentHuman.Show ();
			}
		}

		if (Input.GetKeyUp(KeyCode.H)) {
			if (Input.GetMouseButtonUp (0)) {
				currentHuman.BaseHealth -= 10;
				currentHuman.Show ();
			}
		}


	}
}
