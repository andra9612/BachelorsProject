using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseGenerator : MonoBehaviour {
	[SerializeField]
	private GameObject[] houses = new GameObject[2];
	[SerializeField]
	private GameObject fance;

	[SerializeField]
	private GameObject[]  topPriority;

	[SerializeField]
	private GameObject parent;

	public GameObject bi;

	[SerializeField]
	private GameObject[] equipments = new GameObject[4];

	GameObject building;

	Vector3 zero = Vector3.zero;

	ArrayList coordinates = new ArrayList ();

	Vector3 value;

	GameObject[] furniture;


	public GameObject CreateHouse(){

		building = Instantiate (houses[Random.Range(0,2)],zero,Quaternion.identity,bi.transform);
		CreateHouseEquipment (building);
		return building;
	}


	private void CreateHouseEquipment(GameObject parent){

		int i = 0;
		bool isStorage;
		//ArrayList coordinates = new ArrayList();

		coordinates = GetCoordinates (15, out isStorage, parent.name);

		furniture = new GameObject[coordinates.Count];

		//GameObject[] furniture = new GameObject[coordinates.Count];

		furniture = ChooseElements ( coordinates.Count, isStorage);


		foreach (Vector3 item in coordinates) {

			Instantiate (furniture[i], item, Quaternion.identity, parent.transform);

			i++;
		}

		coordinates.Clear ();

	}


	private GameObject[] ChooseElements( int length, bool isStorage){
		
		GameObject[] choosenElements = new GameObject[length];


		for (int i = 0; i < length; i++) {

			if (isStorage == false) {


				if (i < 2)
					choosenElements [i] = topPriority [i];
				else {
					
					choosenElements [i] = equipments [Random.Range (0, 3)];
				}
				
			} else {

				choosenElements [i] = equipments [Random.Range (1, 4)];
			}
		}

		return choosenElements;

	}


	private ArrayList GetCoordinates(int length, out  bool isStorage, string name ){


		Debug.Log (name);
		ArrayList array = new ArrayList ();

		int[] range = {-4,6,-2,2};

		int countOfTry = 3;

		Vector3[] positions = new Vector3[length];
		Vector3 localPos;

		if (name == "house3(Clone)"){
			range = new int[]{-6,3,-2,5};
		}


		if (Random.Range (1, 11) <= 7) {
			isStorage = false;
		} else {
			isStorage = true;
		}

		for (int i = 0; i < length; i++) {
			value.Set (Random.Range (range[0], range[1]), 0, Random.Range (range[2], range[3]));
			localPos = value;
			//localPos = new Vector3 (Random.Range (range[0], range[1]), 0, Random.Range (range[2], range[3]));

			if (CheckInArray (array, localPos, isStorage) == false) {
				array.Add (localPos);
			} else if(countOfTry != 0) {
				i--;
				countOfTry--;
			}


		}
		return array;
		
	}


	private bool CheckInArray(ArrayList array, Vector3 position, bool isStorage){

		int distance = 0;

		if (isStorage == true)
			distance = 2;
		else
			distance = 3;


		foreach (Vector3 item in array) {
			
			if (Vector3.Distance(item, position) < distance ) {
				return true;
			}
		}

		return false;

	}

}
