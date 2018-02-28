using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell{

	private int _cellIndex;
	private Item _cellItem;
	private Texture2D _cellTexture;

	public Cell(int index, Item item){
		CellIndex = index;
		CellItem = item;
		CellTexture = item.ItemTexture;
	}

	public Cell(int index){
		CellIndex = index;
		//CellItem = new Item();
		CellItem = null;
		//CellTexture = null;
	}

	public Texture2D CellTexture{
		get{ 
			return _cellTexture;
		}
		set{
			_cellTexture = value;
		}
	}

	public int CellIndex{
		get{	
			return _cellIndex;
		}
		set{ 
			_cellIndex = value;
		}
	}

	public Item CellItem{
		get{	
			return _cellItem;
		}
		set{ 
			_cellItem = value;
		}
	}
}
