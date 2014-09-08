using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnerScript: MonoBehaviour {

	private List<Transform> _enemies;
	public Transform        enemyPrefab;
	public Transform        potionPrefab;

	private GameControllerScript _gcScript;

	// Use this for initialization
	public void Spawn(int stage) {
		_gcScript = GameObject.Find ("GameController").GetComponent<GameControllerScript>();
		float interval = Mathf.Max ((9 - stage) * 5.0f, 5.0f);

		_enemies = new List<Transform>();
		for (float z = 25.0f; z <= 500.0f; z += interval) {
			// Pick a random location from -15.0f to 15.0f
			float x = Random.Range (-9.5f, 9.5f);
			var enemy = Instantiate(enemyPrefab) as Transform;
			enemy.position = new Vector3(x, 0.75f, z);
			enemy.parent = this.transform;
			enemy.GetComponent<EnemyScript>().attack = stage;
			_enemies.Add(enemy);
		}

		for (float z = 100.0f; z <= 500.0f; z += 100.0f) {
			float x = Random.Range (-9.5f, 9.5f);
			var potion = Instantiate(potionPrefab) as Transform;
			potion.position = new Vector3(x, 0.75f, z);
			potion.parent = this.transform;
		}
	}
}
