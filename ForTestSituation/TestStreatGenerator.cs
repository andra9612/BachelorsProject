using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStreatGenerator : MonoBehaviour {

	public GameObject streatPrefab;
	public GameObject wastelandPrefab;
	public Transform parent;
	CityMatrixGenerator generator;

	// Use this for initialization
	void Start () {
		generator = new CityMatrixGenerator (30,30);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp(0)) {
			for (int i = 0; i < parent.childCount; i++) {
				Destroy (parent.GetChild (i).gameObject);
			}
			Generate ();
		}
	}

	private void Generate(){
		Square[,] squeres = generator.GenerateSityMatrix ();
		for (int i = 0; i < squeres.GetLength(0); i++) {
			for (int j = 0; j < squeres.GetLength(1); j++) {
				if (squeres [i, j].CurentPrefab == Prefab.Streat)
					Instantiate (streatPrefab,new Vector3(streatPrefab.GetComponent<MeshRenderer>().bounds.size.x * j,0,streatPrefab.GetComponent<MeshRenderer>().bounds.size.z * i),Quaternion.identity,parent);
				else
					Instantiate (wastelandPrefab,new Vector3(streatPrefab.GetComponent<MeshRenderer>().bounds.size.x * j,0,streatPrefab.GetComponent<MeshRenderer>().bounds.size.z * i),Quaternion.identity,parent);
			}
		}
	}
}
