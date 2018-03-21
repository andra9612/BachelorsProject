using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HouseMatrixGenerator{

	public static Square[,] GenerateHouses(Square[,] squareMatrix, int houseCount){
		squareMatrix = FindWastlends (squareMatrix, houseCount);
		return squareMatrix;
	}

	private static Square[,] FindWastlends(Square[,] squareMatrix, int houseCount){
		int counter = 0;
		for (int i = 0; i < squareMatrix.GetLength(0); i++) {
			for (int j = 0; j < squareMatrix.GetLength(1); j++) {
				if (i !=0 && j !=0 && squareMatrix[i,j].CurentPrefab == Prefab.Wasteland) {
					if (CheckAround(squareMatrix,i,j)) {
						squareMatrix [i, j] = new Square (0,Prefab.House,Direction.None);
						counter++;
					}
				}

				if (counter == houseCount)
					return squareMatrix;
			}
		}

		return squareMatrix;
	}

	private static bool CheckAround(Square[,] squareMatrix, int row, int col){
		int rowIndex = row;
		int colIndex = col;
		int counter = 0;
		for (int i = 0; i < 4; i++) {
			switch ((Direction)i) {
			case Direction.Up:
				rowIndex--;
				counter = RecalculateCounter (squareMatrix, rowIndex, colIndex, counter);
				break;
			case Direction.Right:
				colIndex++;
				counter = RecalculateCounter (squareMatrix, rowIndex, colIndex, counter);
				break;
			case Direction.Down:
				rowIndex++;
				counter = RecalculateCounter (squareMatrix, rowIndex, colIndex, counter);
				break;
			case Direction.Left:
				colIndex--;
				counter = RecalculateCounter (squareMatrix, rowIndex, colIndex, counter);
				break;
			}
		}

		if (counter < 4)
			return false;
		return true;
	}

	private static int RecalculateCounter(Square[,] squareMatrix, int row, int col, int counter){
		if (squareMatrix[row,col].CurentPrefab != Prefab.House) {
			counter++;
		}

		return counter;
	}
}
