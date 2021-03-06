﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseGenerator : MonoBehaviour {
	
	public GameObject[] houses = new GameObject[2];
	public Transform allHouses;
	GameObject building;
	Vector3 zero = Vector3.zero;
	public GameObject[] GOArray;

	public GameObject CreateHouse(){

		building = Instantiate (houses[Random.Range(0,2)],zero,Quaternion.identity,allHouses);
		CreateHouseEquipment (building);
		return building;
	}

	private void CreateHouseEquipment(GameObject house){
		Transform places;
		int childCount;
		GameObject decorElement;
		Transform child;
		bool isOneBed = false;
		int index = 0;

		places = house.transform.GetChild (1);
		childCount = places.childCount;

		for (int i = 0; i < childCount; i++) {
			index = Random.Range (0, GOArray.Length);
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
	}
}
