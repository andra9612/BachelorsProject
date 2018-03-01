using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodAndWater : Item {

	private int _nutrition;
	private  int _productType;

	public int Nutrition{
		get{	
			return _nutrition;
		}
		set{ 
			_nutrition = value;
		}
	}

	public int ProductType{
		get{	
			return _productType;
		}
		set{ 
			_productType = value;
		}
	}

}
