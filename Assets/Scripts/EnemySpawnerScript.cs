using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnerScript: MonoBehaviour {

	private List<Transform> _enemies;
	public Transform        enemyPrefab;

	// Use this for initialization
	void Start () {
		_enemies = new List<Transform>();
		for (float z = 25.0f; z <= 500.0f; z += 5.0f) {
			// Pick a random location from -15.0f to 15.0f
			float x = Random.Range (-9.5f, 9.5f);
			var enemy = Instantiate(enemyPrefab) as Transform;
			enemy.position = new Vector3(x, 0.75f, z);
			enemy.parent = this.transform;
			_enemies.Add(enemy);
		}
	}
}
