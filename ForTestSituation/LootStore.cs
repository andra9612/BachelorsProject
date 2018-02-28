using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootStore : MonoBehaviour {

	public List<Item> itemList = new List<Item>();
	public List<Texture2D> textureList = new List<Texture2D>();

	void Start(){
		int max = 0;

		foreach (Texture2D item in textureList) {
			max =Random.Range(1,10);
			itemList.Add (new Item (item, item.name, max, Random.Range (1, max),Random.Range (1, 10)));
		}

	}

}
