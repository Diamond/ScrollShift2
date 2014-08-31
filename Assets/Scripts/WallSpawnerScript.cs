using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallSpawnerScript : MonoBehaviour {

	private List<Transform> _walls;
	public Transform        wallPrefab;

	// Use this for initialization
	void Start () {
		_walls = new List<Transform>();
		for (float z = 25.0f; z <= 500.0f; z += 5.0f) {
			// Pick a random location from -15.0f to 15.0f
			float x = Random.Range (-9.5f, 9.5f);
			var wall = Instantiate(wallPrefab) as Transform;
			wall.position = new Vector3(x, 1.5f, z);
			wall.parent = this.transform;
			_walls.Add(wall);
		}
	}
}
