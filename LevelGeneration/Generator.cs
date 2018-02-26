using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Generator : MonoBehaviour {

	protected ArrayList coordinatePool;

	public abstract void GetCoordinate (ArrayList coordinate);


	protected bool CheckPosition(ArrayList X, Vector3 coordinate, int distance){

		foreach (Vector3 item in X) {
			if ( Vector3.Distance(item, coordinate) < distance  ) {
				return true;
			}
		}

		return false;
	}

}
