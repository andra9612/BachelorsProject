using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CityMatrixGenerator{

	private int _rows;
	private int _columns;
	private int _lastIndex;

	public int Rows{
		get{ 
			return _rows;
		}
		set{ 
			if (value <= 0)
				_rows = 1;
			else
				_rows = value;
		}
	}

	public int Columns{
		get{ 
			return _columns;
		}
		set{ 
			if (value <= 0)
				_columns = 1;
			else
				_columns = value;
		}
	}
		
	public CityMatrixGenerator(int row, int col){
		Rows = row;
		Columns = col;
		_lastIndex = 1;
	}

	public Square[,] GenerateSityMatrix(){
		int streatCount = 0;
		Square[,] squareMatrix = new Square[Rows,Columns];

		for (int i = 0; i < squareMatrix.GetLength(0); i++) {
			for (int j = 0; j < squareMatrix.GetLength(1); j++) {
				squareMatrix [i, j] = new Square ();
			}
		}
		ChoseMainStreat (ref squareMatrix);

		streatCount = Random.Range (1,5);

		for (int i = 0; i < streatCount; i++) {
			squareMatrix = GenerateRandomStreat (squareMatrix);
		}

		_lastIndex = 0;
		return squareMatrix;
	}

	private Square[,] GenerateRandomStreat(Square[,] squareMatrix){
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

			if(counter == 12)
				return squareMatrix;

		} while (!isEnd);

		return squareMatrix;

	}

	private bool CheckIfItsPossibleToGenerateStreat(ref Square[,] squareMatrix, int index, Direction direction){
		int row = 0;
		int col = 0;
		bool isEnd = false;
		for (int i = 0; i < squareMatrix.GetLength(0); i++) {
			for (int j = 0; j < squareMatrix.GetLength(1); j++) {
				if (squareMatrix[i,j].StreatIndex == index) {
					row = i;
					col = j;

					CenterForCurrentDirection (ref row, ref col,squareMatrix[row,col].CurrentDirection,direction);
					if (!CheckNextSquares (squareMatrix, direction, col, row))
						isEnd = true;
					else 
						squareMatrix = FillCells (squareMatrix,col,row,3,Prefab.Streat,direction);

					if (isEnd)
						return false;
				}

			}
		}
		return true;
	}

	private void CenterForCurrentDirection(ref int row, ref int col, Direction curDirection,Direction direction){
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

	private bool CheckNextSquares(Square[,] squareMatrix,Direction direction, int col, int row){
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

		private void GetNext (ref int row, ref int col,Direction direction){
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

	private void  ChoseMainStreat(ref Square[,] squareMatrix){
		int randomSide = 0;//chose rows or columns
		int randomIndex = 0;//index of row or col for creatingThe Streat

		randomSide = Random.Range (0,2);//0- rows, 1 - columns
		if (randomSide == 0) {
			randomIndex = Random.Range (0, Rows);
			squareMatrix = FillCells (squareMatrix,0,randomIndex,squareMatrix.GetLength(0),Prefab.Streat,Direction.Right);

		} else {
			randomIndex = Random.Range (0, Columns);
			squareMatrix = FillCells (squareMatrix,randomIndex,0,squareMatrix.GetLength(1),Prefab.Streat,Direction.Down);
		}
	}

	private Square[,] FillCells(Square[,] squareMatrix,int colIndex, int rowIndex , int count, Prefab prefab, Direction direction ){
		int counter = 0;
		int iterationCounter = 0;

		for (int i = 0; i < squareMatrix.GetLength(0); i++) {
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
		}

		return squareMatrix;
	}


}
