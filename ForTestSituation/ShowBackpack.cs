using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBackpack : MonoBehaviour {

	Backpack backpack;
	Backpack chest;
	private const  int CELL_WIDTH = 40;
	private const  int CELL_HEIGTH = 40;
	Human human;

	Rect inventoryWindowRect = new Rect (10,10,230,265);
	Rect chestWindow = new Rect(120,120, 230,265);

	int row = 0;
	int column = 0;

	List<Item> items1 = new List<Item>();
	List<Item> items2 = new List<Item>();

	bool isOpenedBackpack = false;
	bool isOpenedChest = false;

	Rect coordinateRect;
	
        public GameObject chosenChest;
	
	// Use this for initialization
	void Start () {
		human = GameObject.Find ("Player").GetComponent<Human> ();
		backpack = GameObject.Find ("Player").GetComponent<Backpack>();
		chest =  GameObject.Find ("Chest").GetComponent<Backpack>();
		items1 = GameObject.Find ("LootStore").GetComponent<LootStore> ().itemList1;
		items2 = GameObject.Find ("LootStore").GetComponent<LootStore> ().itemList2;
		row = 6;
		column = 4;
		chest.InitializeCellMatrix (row,column);
		backpack.InitializeCellMatrix (row, column);

		int i = 0;
		int j = 0;
		int counter = 0;

		foreach (Item item in items1) {
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
		foreach (Item item in items2) {
			chest.cellMatrix [i, j] = new Cell (counter, item);
			j++;
			counter++;
			if (j >= chest.cellMatrix.GetLength (1)) {
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
					if (Input.GetMouseButtonUp (1)) {
						cell.CellItem.UseItem (human);
						if (cell.CellItem.NowInStack == 0)
							cell.CellItem = null;
					} else {
						Debug.Log (cell.CellItem);
						cell.CellItem = recipient.Add (cell.CellItem);
					}
				}
			}
		} else {
			if (GUI.Button (coordinateRect, cell.CellIndex.ToString ())) {
				Debug.Log (cell.CellIndex);
				if (human.PersonWeapon != null){
					cell.CellItem = human.PersonWeapon;
					cell.CellItem.NowInStack++;
					human.PersonWeapon = null;
				}
			}
		}
	}


}

