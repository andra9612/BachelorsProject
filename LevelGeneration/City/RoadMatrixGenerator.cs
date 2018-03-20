using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class RoadMatrixGenerator{

	 static int _lastIndex;

		
	/*public RoadMatrixGenerator(int row, int col){
		Rows = row;
		Columns = col;
		_lastIndex = 1;
	}*/

	public static Square[,] GenerateSityMatrix(Square[,] squareMatrix){
		int streatCount = 0;
		_lastIndex = 0;
		for (int i = 0; i < squareMatrix.GetLength(0); i++) {
			for (int j = 0; j < squareMatrix.GetLength(1); j++) {
				squareMatrix [i, j] = new Square ();
			}
		}
		ChoseMainStreat (ref squareMatrix,squareMatrix.GetLength(0),squareMatrix.GetLength(1));

		streatCount = Random.Range (50,131);

		for (int i = 0; i < streatCount; i++) {
			squareMatrix = GenerateRandomStreat (squareMatrix);
		}

		_lastIndex = 0;
		return squareMatrix;
	}

	private static Square[,] GenerateRandomStreat(Square[,] squareMatrix){
		int randomIndex = 0;
		int counter = 0;
		bool isEnd = false;

		do {
			randomIndex = Random.Range (1, _lastIndex);
			for (int i = 0; i < 4; i++) {
				if(CheckIfItsPossibleToGenerateStreat(ref squareMatrix,randomIndex,(Direction)i)){
					isEnd = true;
					break;
				}
				else
					counter++;
			}

			if(counter == 20)
				return squareMatrix;

		} while (!isEnd);

		return squareMatrix;

	}

	private static bool CheckIfItsPossibleToGenerateStreat(ref Square[,] squareMatrix, int index, Direction direction){
		int row = 0;
		int col = 0;
		bool isEnd = false;
		for (int i = 0; i < squareMatrix.GetLength(0); i++) {
			for (int j = 0; j < squareMatrix.GetLength(1); j++) {
				if (squareMatrix[i,j].StreatIndex == index) {
					row = i;
					col = j;

					//GetNext (ref row, ref col, direction);
					CenterForCurrentDirection (ref row, ref col,squareMatrix[row,col].CurrentDirection,direction);
					if (!CheckNextSquares (squareMatrix, direction, col, row))
						isEnd = true;
					else {
						squareMatrix = FillCells (squareMatrix, col, row, 3, Prefab.Streat, direction);
						return true;
					}

					if (isEnd)
						return false;
				}

			}
		}
		return true;
	}

	private static void CenterForCurrentDirection(ref int row, ref int col, Direction curDirection,Direction direction){
		if (curDirection == Direction.Left || curDirection == Direction.Right) {
			switch (direction) {
			case Direction.Left:
				col--;
				break;
			case Direction.Right:
				col += 3;
				break;
			case Direction.Down:
				col++;
				row++;
				break;
			case Direction.Up:
				col++;
				row--;
				break;
			}
		}else{
				switch (direction) {
				case Direction.Left:
					col--;
					row++;
					break;
				case Direction.Right:
					col++;
					row++;
					break;
				case Direction.Down:
					row+=3;
					break;
				case Direction.Up:
					row++;
					break;
				}

			}
	}

	private static bool CheckNextSquares(Square[,] squareMatrix,Direction direction, int col, int row){
		int counter = 0;
		bool isEnd = false;
		for (int i = 0; i < 3; i++) {
			if (row < squareMatrix.GetLength (0) && col < squareMatrix.GetLength (1) && row >= 0 && col >=0){
				switch (direction) {
				case Direction.Up:
						if (squareMatrix [row, col].CurentPrefab != Prefab.Wasteland)
							isEnd = true;
					break;
				case Direction.Right:
						if (squareMatrix [row, col].CurentPrefab != Prefab.Wasteland)
							isEnd = true;
		
					break;
				case Direction.Down:
						if (squareMatrix [row, col].CurentPrefab != Prefab.Wasteland)
							isEnd = true;
					break;
				case Direction.Left:
						if (squareMatrix [row, col].CurentPrefab != Prefab.Wasteland)
							isEnd = true;
					break; 
				}
				GetNext (ref row, ref col, direction);
				//CenterForCurrentDirection (ref row,ref col,squareMatrix[row,col].CurrentDirection,direction);
			}else
				isEnd = true;
			
			if (isEnd)
				return false;
		}

		return true;
	}

	private static void GetNext (ref int row, ref int col,Direction direction){
		switch (direction) {
		case Direction.Up:
			row--;
			break;
		case Direction.Right:
			col++;
			break;
		case Direction.Down:
			row++;
			break;
		case Direction.Left:
			col--;
			break;
		}
	}

	private static void  ChoseMainStreat(ref Square[,] squareMatrix, int rows, int cols){
		int randomSide = 0;//chose rows or columns
		int randomIndex = 0;//index of row or col for creatingThe Streat

		randomSide = Random.Range (0,2);//0- rows, 1 - columns
		if (randomSide == 0) {
			randomIndex = Random.Range (0, rows);
			squareMatrix = FillCells (squareMatrix,0,randomIndex,squareMatrix.GetLength(0),Prefab.Streat,Direction.Right);

		} else {
			randomIndex = Random.Range (0, cols);
			squareMatrix = FillCells (squareMatrix,randomIndex,0,squareMatrix.GetLength(1),Prefab.Streat,Direction.Down);
		}
	}

	private  static Square[,] FillCells(Square[,] squareMatrix,int colIndex, int rowIndex , int count, Prefab prefab, Direction direction ){
		int counter = 0;
		int iterationCounter = 0;

		/*for (int i = 0; i < squareMatrix.GetLength(0); i++) {
			for (int j = 0; j < squareMatrix.GetLength (1); j++) {
				if (counter != count) {
					if (i == rowIndex && j == colIndex) {
						squareMatrix [i, j].CurentPrefab = prefab;
						squareMatrix [i, j].StreatIndex = _lastIndex;
						squareMatrix [i, j].CurrentDirection = direction;

						iterationCounter++;
						counter++;

						switch (direction) {
						case Direction.Up:
							rowIndex--;
							break;
						case Direction.Right:
							colIndex++;
							break;
						case Direction.Down:
							rowIndex++;
							break;
						case Direction.Left:
							colIndex--;
							break;
						}

						if (iterationCounter == 3) {
							_lastIndex++;
							iterationCounter = 0;
						}

					}
				} else {
					return squareMatrix;
				}

			}
		}*/

		for (int i = 0; i < count; i++) {
			squareMatrix [rowIndex, colIndex].CurentPrefab = prefab;
			squareMatrix [rowIndex, colIndex].StreatIndex = _lastIndex;
			squareMatrix [rowIndex, colIndex].CurrentDirection = direction;

			iterationCounter++;
			counter++;

			GetNext (ref rowIndex,ref colIndex,direction);

			/*switch (direction) {
			case Direction.Up:
				rowIndex--;
				break;
			case Direction.Right:
				colIndex++;
				break;
			case Direction.Down:
				rowIndex++;
				break;
			case Direction.Left:
				colIndex--;
				break;
			}*/

			if (iterationCounter == 3) {
				_lastIndex++;
				iterationCounter = 0;
			}
		}

		return squareMatrix;
	}


}
