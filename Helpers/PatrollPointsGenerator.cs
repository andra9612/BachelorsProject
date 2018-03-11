using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrollPointsGenerator : MonoBehaviour
{

	public Vector3 [] GeneratePoints(GameObject house)
	{
		Vector3 [] points = new Vector3[50];
		int index = 0, axis, x, z;
		float xPosition, zPosition;
		float housePositionX= house.transform.position.x;
		float housePositionZ = house.transform.position.z;
		float housePositionXPlus = housePositionX + 50;
		float housePositionZPlus = housePositionZ + 50;
		while (index != 50) 
		{
			axis = Random.Range (0, 2);
			switch (axis)
			{
			case 0:
				x = Random.Range (housePositionX - 30, housePositionXPlus + 30);
				xPosition = x;
				if (x <= housePositionXPlus && x > housePositionX) {
					z = Random.Range (0, 2);
					if (z == 0) {
						zPosition = Random.Range (housePositionZ - 30, housePositionZ);
					} else {
						zPosition = Random.Range (housePositionZPlus, housePositionZPlus + 30);
					}
				} else {
					zPosition = Random.Range (housePositionZ - 30, housePositionZPlus + 30);
				}
					break;
			case 1:
				z = Random.Range (housePositionZ - 30, housePositionZPlus + 30);
				zPosition = z;
				if (z <= housePositionZPlus && Z > housePositionZ) {
					x = Random.Range (0, 2);
					if (x == 0) {
						xPosition = Random.Range (housePositionX - 30, housePositionX);
					} else {
						xPosition = Random.Range (housePositionXPlus, housePositionXPlus + 30);
					}
				} else {
					xPosition = Random.Range (housePositionX - 30, housePositionXPlus + 30);
				}
					break;
			}
			points [index] = new Vector3 (xPosition, 0, zPosition);
			index++;
		}
		return points;

	}



}


