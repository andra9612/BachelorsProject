using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour {

	private  int _rowCount;
	private  int _columnCount;

	public Cell[,] cellMatrix;

	/*void Start(){
		InitializeCellMatrix ();
	}*/

	public void InitializeCellMatrix(int row, int col){
		int counter = 0;

		RowCount = row;
		ColumnCount = col;

		cellMatrix = new Cell[RowCount, ColumnCount];

		for (int i = 0; i < RowCount; i++) {
			for (int j = 0; j < ColumnCount; j++) {
				cellMatrix [i, j] = new Cell (counter);
				counter++;
			}
		}
	}



	public Item  Add(Item  item){
		int checker = 0;

		for (int i = 0; i < cellMatrix.GetLength(0); i++) {
			for (int j = 0; j < cellMatrix.GetLength(1); j++) {
				if (cellMatrix [i, j].CellItem != null) {
					if (cellMatrix [i, j].CellItem.ItemName == item.ItemName) {
						if (cellMatrix [i, j].CellItem.NowInStack != cellMatrix [i, j].CellItem.MaxInStack) {
							checker = item.NowInStack + cellMatrix [i, j].CellItem.NowInStack;
							if (checker > cellMatrix [i, j].CellItem.MaxInStack) {
								checker = cellMatrix [i, j].CellItem.MaxInStack - cellMatrix [i, j].CellItem.NowInStack;
								item.NowInStack -= checker;
								cellMatrix [i, j].CellItem.NowInStack = cellMatrix [i, j].CellItem.MaxInStack;
								return item;
							} else {
								cellMatrix [i, j].CellItem.NowInStack += item.NowInStack;
								return null;
							}
						}
					}
				}
			}
		}

		for (int i = 0; i < cellMatrix.GetLength(0); i++) {
			for (int j = 0; j < cellMatrix.GetLength(1); j++) {
				if (cellMatrix [i, j].CellItem == null) {
					cellMatrix [i, j].CellItem = item;
					//cellMatrix [i, j].CellItem = new Item(item.ItemTexture,item.ItemName,item.MaxInStack,item.NowInStack,item.Durability);
					return null;
				}
			}
		}

		return item;
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
