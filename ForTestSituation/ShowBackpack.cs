using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBackpack : MonoBehaviour {

	Backpack backpack;
	private const  int CELL_WIDTH = 10;
	private const  int CELL_HEIGTH = 20;

	int row = 0;
	int column = 0;

	// Use this for initialization
	void Start () {
		backpack = GameObject.Find ("Backpack").GetComponent<Backpack>();

		backpack.ColumnCount = 3;
		backpack.RowCount = 2;

		row = backpack.RowCount;
		column = backpack.ColumnCount;
			
	}

	void OnGUI(){
		GUI.BeginGroup (new Rect(10, 10, 200,400));
		GUI.Box (new Rect(10, 10, 200,400), "Inventory");
		for (int i = 0; i < row; i++) {
			for (int j = 0; j < column; j++) {
				GUI.Button (new Rect(50 +column ,50 + row,CELL_WIDTH,CELL_HEIGTH),backpack.cellMatrix[i,j].CellIndex.ToString());
			}
		}
		GUI.EndGroup();
	}

}
