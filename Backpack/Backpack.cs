using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour {
	private const  int CELL_WIDTH = 10;
	private const  int CELL_HEIGTH = 20;

	private  int _rowCount;
	private  int _columnCount;

	public Cell[,] cellMatrix;

	void Start(){
		InitializeCellMatrix ();
	}

	private void InitializeCellMatrix(){
		int counter = 0;
		cellMatrix = new Cell[RowCount, ColumnCount];

		for (int i = 0; i < RowCount; i++) {
			for (int j = 0; j < ColumnCount; j++) {
				cellMatrix [i, j] = new Cell (counter);
				counter++;
			}
		}
	}

	public int ColumnCount{
		get{	
			return _columnCount;
		}
		set{ 
			_columnCount = value;
		}
	}

	public int RowCount{
		get{	
			return _rowCount;
		}
		set{ 
			_rowCount = value;
		}
	}





}
