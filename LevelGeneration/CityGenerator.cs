using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityGenerator : Generator {

	//public GameObject[] houses = new GameObject[2];

	//public GameObject center;

	HouseGenerator generator;

	ArrayList coordinatePool;



	Vector3 localVariable;	//coordinate of house
	bool isEmpty = false;	//check that we need to put new coordinate into coordinate pool   	 
	int streatLength = 0;	//length of streat 
	int sizeOfArea = 20;	//size of area in whitch we create houses
	int difference = 0;		//difference  between sizeOfArea and streatLength	


	bool isBranching = true;				//variable for check  - we need to brankh or not
	Vector3 startPosition;					//start position
	float moveX = 20, moveZ = 20;			//how much we should move
	bool isEnd = false;

	void Start(){
		
		GameObject clone;

		coordinatePool = new ArrayList ();

		generator = GetComponent<HouseGenerator> ();

		GetCoordinate (coordinatePool);

		foreach (Vector3 item in coordinatePool) {
			clone = generator.CreateHouse ();
			clone.transform.position = item;
			clone.transform.rotation = Quaternion.Euler (new Vector3(0 ,90 * Random.Range(0,5),0)); 
		}
	}


	public override void GetCoordinate(ArrayList array){
		int counter = 0;
		for (int i = 0; i < sizeOfArea; i++) {
			for (int j = 0; j < sizeOfArea; j++) {
				if (Random.Range(1,11) < 7){
				//if (Random.Range(1,11) < 5 &&( ((i*10)<200 || (i*10)>250 ) || ( (j*10)<200 || (j*10)>250)) ){
					localVariable.Set(i*50, 0 , j*50);
					array.Add(localVariable);
					counter++;
				}
			}
		}

		Debug.Log (counter);

	}

	/*public override void  GetCoordinate(ArrayList array){

		for (int i = 0; i < sizeOfArea; i++) {
			
			for (int j = 0; j < sizeOfArea; j++) {

				if (streatLength == 0) {
					streatLength = Random.Range (1, sizeOfArea - difference + 1 );
					difference += streatLength;

					if (Random.Range (0, 11) < 2)
						isEmpty = false;
					else
						isEmpty = true;
				}

				if (isEmpty == false) {
					localVariable.Set (j* 40, 0, i* 40);
					array.Add (localVariable);
				} 

				streatLength--;
			}
			difference = 0;
		}
		
	}

	// Use this for initialization
	/*void Start () {

		Vector3 coordinate;

		GameObject house;

		ArrayList position = new ArrayList ();

		generator = GetComponent<HouseGenerator> ();
	
		int countOfHouse = Random.Range(100,120);

		GetNewPosition1 (position);

		foreach (Vector3 item in position) {
			
			house = generator.CreateHouse ();
			house.transform.position = item;
			house.transform.Rotate (0f, Random.Range (0, 5) * 90f, 0);
		}

	}


	/*private void GetNewPosition1(ArrayList position){

		bool isEnd = true;
		Vector3 point = Vector3.zero;

		Vector3 value = new Vector3 ();

		int counter = 0;
		int lengthOfStreat = 0; 

		int countOfHouses = Random.Range (300, 600);
		for (int i = 0; i < countOfHouses; i++) {

			if (isEnd) {

				lengthOfStreat = Random.Range (1, 10);
				value.Set (Random.Range (0, 1000), 0, Random.Range (0, 1000));
				point = value;
				//point = new Vector3 (Random.Range (0, 1000), 0, Random.Range (0, 1000));

				isEnd = false;
			}

			if (isEnd ==  false) {

				if (Random.Range(0,2) == 0) {
					point.x +=20;
				}
				else{
					point.z += 20;
				}

				//if (point.x > 490 || point.z > 490)
				//	isEnd = true;

				if(counter == lengthOfStreat)
					isEnd = true;

				if (CheckPosition (position, point) || point.x > 1000 || point.z > 1000) {
					isEnd = true;
					i--;
				}

				else {
					position.Add (point);

					counter++;
				}
					
			}

		}

	}



	private bool CheckPosition(ArrayList X, Vector3 coordinate){

		int distance;

		if (Random.Range (0, 2) == 0)
			distance = 20;
		else
			distance = 25;

		foreach (Vector3 item in X) {
			if ( Vector3.Distance(item, coordinate) < distance  ) {
				return true;
			}
		}

		return false;
	}*/
}
