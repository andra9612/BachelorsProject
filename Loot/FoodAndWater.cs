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



	public FoodAndWater(Texture2D texture, string name, int maxInStack, int nowInStack, int  durability, ItemType itemType,ProductType type )
		:base(texture,name,maxInStack,nowInStack,durability,ItemType.Food)
	{
		TypeOfProduct = type;
	}

	public override void UseItem (Human human)
	{
		Debug.Log ("Eat or drink smth");

		if (TypeOfProduct == ProductType.Drink) {
			Debug.Log ("Thirst");
			human.Thirst += Durability;

		} else {
			Debug.Log ("Hunger");
			human.Hunger += Durability;
		}

		NowInStack--;
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
