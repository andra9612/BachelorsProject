using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Item  {

	private Texture2D _itemTexture;
	private string _itemName;
	private int _maxInStack;
	private int _nowInStack;
	private int _durability;

	public Item(Texture2D texture, string name, int maxInStack, int nowInStack, int  durability){
		ItemTexture = texture;
		ItemName = name;
		MaxInStack = maxInStack;
		NowInStack = nowInStack;
		Durability = durability;
	}

	public Item(){
		ItemTexture = null;
		ItemName = string.Empty;
		MaxInStack = 0;
		NowInStack = 0;
		Durability = 0;
	}

	public int Durability{
		get{	
			return _durability;
		}
		set{ 
			_durability = value;
		}
	}

	public Texture2D ItemTexture{
		get{ 
			return _itemTexture;
		}
		set{
			_itemTexture = value;
		}
	}

	public string ItemName{
		get{ 
			return _itemName;
		}

		set{ 
			_itemName = value;
		}
	}

	public int MaxInStack{
		get{ 
			return _maxInStack;
		}

		set{
			_maxInStack = value;
		}
	}

	public int NowInStack{
		get{
			return _nowInStack;
		}

		set{ 
			_nowInStack = value;
		}

	}
		
}
