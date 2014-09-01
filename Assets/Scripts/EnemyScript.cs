using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyScript : MonoBehaviour {
	public List<Sprite> faces;
	public GameControllerScript gcScript;
	public bool alive = false;

	void Start() {
		gcScript = GameObject.Find ("GameController").GetComponent<GameControllerScript>();
		alive = true;
		this.GetComponent<SpriteRenderer>().sprite = faces[Random.Range (0, faces.Count)];
	}

	void OnCollisionEnter(Collision c) {
		if (!alive) return;
		if (c.gameObject.tag == "Player") {
			Destroy (this.gameObject);
			gcScript.HurtPlayer(1);
		}
	}

	void OnTriggerEnter(Collider c) {
		if (!alive) return;
		if (c.gameObject.tag == "Bullet") {
			this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
			this.particleSystem.Play();
			//Destroy (this.gameObject);
			Destroy (c.gameObject);
			gcScript.xp += 1;
			alive = false;
		}
	}
}
