using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBackpack : MonoBehaviour {

	Backpack backpack;
	Backpack chest;
	private const  int CELL_WIDTH = 40;
	private const  int CELL_HEIGTH = 40;

	Rect inventoryWindowRect = new Rect (10,10,230,265);
	Rect chestWindow = new Rect(120,120, 230,265);

	int row = 0;
	int column = 0;

	List<Item> items = new List<Item>();

	bool isOpenedBackpack = false;
	bool isOpenedChest = false;

	Rect coordinateRect;

	// Use this for initialization
	void Start () {
		backpack = GameObject.Find ("Player").GetComponent<Backpack>();
		chest =  GameObject.Find ("Chest").GetComponent<Backpack>();
		items = GameObject.Find ("LootStore").GetComponent<LootStore> ().itemList;
		row = 6;
		column = 4;
		chest.InitializeCellMatrix (row,column);
		backpack.InitializeCellMatrix (row, column);

		int i = 0;
		int j = 0;
		int counter = 0;
		foreach (Item item in items) {
			backpack.cellMatrix [i, j] = new Cell (counter, item);
			j++;
			counter++;
			if (j >= backpack.cellMatrix.GetLength (1)) {
				i++;
				j = 0;
			}
		}

		i = 0;
		j = 0;
		counter = 0;
		foreach (Item item in items) {
			chest.cellMatrix [i, j] = new Cell (counter,new Item(item.ItemTexture,item.ItemName,item.MaxInStack,item.NowInStack,item.Durability));
			j++;
			counter++;
			if (j >= backpack.cellMatrix.GetLength (1)) {
				i++;
				j = 0;
			}
		}
			
	}
		
	void Update(){
		if (Input.GetKeyUp (KeyCode.Tab))
			isOpenedBackpack = !isOpenedBackpack;

		if (Input.GetKeyUp (KeyCode.LeftControl))
			isOpenedChest = !isOpenedChest;
	}

	void OnGUI() 
	{ 
		if (isOpenedBackpack) {
			inventoryWindowRect = GUI.Window (1, inventoryWindowRect, firstInventory, "INVENTORY");
		}else
			inventoryWindowRect = new Rect (10,10,230,265);
		
		if (isOpenedChest) {
			chestWindow = GUI.Window (2, chestWindow, ChestWindow, "CHEST");
		}else
			chestWindow = new Rect(120,120, 230,265);
	} 


	void ChestWindow(int id){
		for (int y = 0; y < row; y++) { 
			for (int x = 0; x < column; x++) { 
				coordinateRect = new Rect (20 + (x * CELL_HEIGTH), 20 + (y * CELL_WIDTH), CELL_WIDTH, CELL_HEIGTH);
				ShowInventory (chest.cellMatrix [y, x],coordinateRect,chest,backpack);
			} 
		}

		GUI.DragWindow ();
	}

	void firstInventory(int id)
	{ 
		for (int y = 0; y < row; y++) { 
			for (int x = 0; x < column; x++) { 
				coordinateRect = new Rect (20 + (x * CELL_HEIGTH), 20 + (y * CELL_WIDTH), CELL_WIDTH, CELL_HEIGTH);
				ShowInventory (backpack.cellMatrix [y, x],coordinateRect,backpack,chest);
			} 
		}

		GUI.DragWindow ();
	}

	private void ShowInventory(Cell cell, Rect coordinateRect, Backpack donor, Backpack recipient){
		if (cell.CellItem != null) {
			GUI.Label (coordinateRect,cell.CellItem.MaxInStack.ToString());
			GUI.Label (new Rect(coordinateRect.x,coordinateRect.y+20,coordinateRect.width,coordinateRect.height),cell.CellItem.NowInStack.ToString());
			if (GUI.Button (coordinateRect, cell.CellItem.ItemTexture)) {
				if (isOpenedChest  && isOpenedBackpack) {
					cell.CellItem = recipient.Add (cell.CellItem);
					Debug.Log (cell.CellIndex);
				}
			}
		} else {
			if (GUI.Button (coordinateRect,cell.CellIndex.ToString())) {
				Debug.Log (cell.CellIndex);
			}
		}
	}


}
