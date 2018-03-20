using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator{

	private int _rows;
	private int _columns;
	private Square[,] squareMatrix;

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

	public MapGenerator(int rows, int cols){
		Rows = rows;
		Columns = cols;
		squareMatrix = new Square[Rows,Columns];
	}

	public Square[,] GenerateMap(){
		squareMatrix = RoadMatrixGenerator.GenerateSityMatrix (squareMatrix);
		return squareMatrix;
	}
}
