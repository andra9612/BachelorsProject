using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FoodAndWater:Item {

	public enum ProductType 
	{
		Food,
		Drink
	}

	private  ProductType _productType;


	public FoodAndWater(Texture2D texture, string name, int maxInStack, int nowInStack, int  durability, ItemType itemType,ProductType type ){
		ItemTexture = texture;
		ItemName = name;
		MaxInStack = maxInStack;
		NowInStack = nowInStack;
		Durability = durability;
		Type = itemType;
		TypeOfProduct = type;
	}


	public ProductType TypeOfProduct{
		get{	
			return _productType;
		}
		set{ 
			_productType = value;
		}
	}

}
