using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootStore : MonoBehaviour {

	public List<Item> itemList = new List<Item>();
	public Texture2D[] textureArray = new Texture2D[5];
	//public List<Texture2D> textureList = new List<Texture2D>();

	void Start(){
		int max = 0;

		itemList.Add (new MeleeWeapon (textureArray[0], "sword1", 1, 1,Random.Range (1, 10),Item.ItemType.MeleeWeapon,Random.Range (1, 10),5,10));
		itemList.Add (new MeleeWeapon (textureArray[1], "sword1", 1, 1,Random.Range (1, 10),Item.ItemType.MeleeWeapon,Random.Range (1, 10),5,7));
		itemList.Add (new MeleeWeapon (textureArray[2], "sword1", 1, 1,Random.Range (1, 10),Item.ItemType.MeleeWeapon,Random.Range (1, 10),5,15));
		itemList.Add (new FoodAndWater (textureArray[3], "food", 5, Random.Range (1, 5),Random.Range (1, 10),Item.ItemType.Food,FoodAndWater.ProductType.Food));
		itemList.Add (new FoodAndWater (textureArray[4], "milk", 5, Random.Range (1, 5),Random.Range (1, 10),Item.ItemType.Food,FoodAndWater.ProductType.Drink));
		itemList.Add (new Item (textureArray[5], "Staf", 10, Random.Range (1, 10),Random.Range (1, 10),Item.ItemType.Item));

		/*foreach (Texture2D item in textureList) {
			max =Random.Range(1,10);
			itemList.Add (new Item (item, item.name, max, Random.Range (1, max),Random.Range (1, 10),));
		}*/

	}

}
