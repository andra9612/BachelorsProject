using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseEquipment : MonoBehaviour {
	
	public GameObject[] GOArray;

	public GameObject PutEquipment(GameObject house){
		Transform places;
		int childCount;
		GameObject decorElement;
		Transform child;
		bool isOneBed = false;
		int index = 0;

		places = house.transform.GetChild (1);
		childCount = places.childCount;

		for (int i = 0; i < childCount; i++) {
			index = Random.Range (0, GOArray.Length - 1);
			child = places.GetChild (i);

			if (GOArray [index].name == "Bed") {
				if(isOneBed == false && house.name !="house1(Clone)"){
					decorElement = Instantiate (GOArray [index], places.GetChild (i).position, Quaternion.identity, child);
					decorElement.transform.LookAt (child.GetChild (0));
					isOneBed = true;
				}else
					i--;
			} else {
				decorElement = Instantiate (GOArray [index], places.GetChild (i).position, Quaternion.identity, child);
				decorElement.transform.LookAt (child.GetChild (0));
			}


		}

		return house;
	}
}
