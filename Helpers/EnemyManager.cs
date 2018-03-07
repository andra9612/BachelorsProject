/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	public GameObject enemy;                // The enemy prefab to be spawned.
	public float spawnTime = 3f;            // How long between each spawn.
	private int spawnPointIndexX;
	private int spawnPointIndexZ;

	void Start ()
	{
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}


	void Spawn ()
	{

		spawnPointIndexX = Random.Range (0, 150);
		spawnPointIndexZ = Random.Range (0, 150);
		Instantiate (enemy, new Vector3(spawnPointIndexX, enemy.gameObject.GetComponent<Collider>().bounds.size.y, spawnPointIndexZ), Quaternion.identity);
	}
}
*/