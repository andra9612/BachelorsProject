using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBuilding : MonoBehaviour {
	[SerializeField]
	private GameObject floor;
	[SerializeField]
	private GameObject wall;
	[SerializeField]
	private GameObject window;
	[SerializeField]
	private GameObject door;

	private float instX = 0;
	private float instZ = 0;

	private float lengthX;
	private float lengthZ;


	//you enter count of floor elements and function return  house
	public GameObject CreateHouse(int floorCount){
		
		GameObject parent = new GameObject ("house");
		parent.transform.position = new Vector3 (0, 0, 0);


		string[] previousPos =  new string[floorCount+1];

		string twoValue;

		int randomValue;

		bool isUnique = false;


		for (int i = 1; i < floorCount+1; i++) {

			randomValue = Random.Range (0, 5);

			switch (randomValue) {
			case 0:
				instZ -= lengthZ;
				break;
			case 1:
				instZ += lengthZ;
				break;
			case 2:
				instX += lengthX- 0.5f;
				break;
			case 3:
				instX -= lengthX-0.5f;
				break;
			}

			twoValue = instX.ToString () + ":" + instZ.ToString ();

			isUnique = CheckInArray (previousPos, twoValue);

			Debug.Log (randomValue + "\n" + instX + "........." + instZ);

			if (isUnique) {
				Instantiate (floor, new Vector3 (instX, 0, instZ), Quaternion.identity, parent.transform);
				for (int j = 0; j < 4; j++) {
					Instantiate (wall, new Vector3 (instX, 0, instZ), Quaternion.identity,parent.transform);
				}

				previousPos [i] = twoValue;
			} else
				i--;

		}




		return parent;
	}
		

	bool CheckInArray(string[] array, string val){

		if (array == null) 
			return false;

		for (int i = 0; i < array.Length; i++) {
			if (array[i] == val) {
				return false;
			}
		}

		return true;
	}

	// Use this for initialization
	void Start () {
		

	}

}
