using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallSpawnerScript : MonoBehaviour {

	private List<Transform> _walls;
	public Transform        wallPrefab;
	public List<Transform>  wallChoices;

	// Use this for initialization
	void Start () {
		_walls = new List<Transform>();
		for (float z = 25.0f; z <= 500.0f; z += 5.0f) {
			int wallChoice = Random.Range (0, 5);
			Vector2 placement = PlacementForWallChoice(wallChoice);
			var wall = Instantiate(wallChoices[wallChoice]) as Transform;
			wall.position = new Vector3(placement.x, placement.y, z);
			wall.parent = this.transform;
			_walls.Add(wall);
		}
	}

	Vector2 PlacementForWallChoice(int choice) {
		switch(choice) {
		case 4:
			return new Vector2(Random.Range (-9.5f, 9.5f), 0f);
		case 3:
			return new Vector2(Random.Range (-8.5f, 8.5f), 0f);
			break;
		case 2:
			return new Vector2(Random.Range (-8.5f, 8.5f), 0f);
			break;
		case 1:
			return new Vector2(Random.Range (-9.5f, 9.5f), 0f);
			break;
		case 0:
		default:
			return new Vector2(Random.Range (-9.5f, 9.5f), 0f);
			break;
		}
	}
}
