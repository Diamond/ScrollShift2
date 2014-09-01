using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	public GameControllerScript gcScript;

	void Start() {
		gcScript = GameObject.Find ("GameController").GetComponent<GameControllerScript>();
	}

	void OnCollisionEnter(Collision c) {
		if (c.gameObject.tag == "Player") {
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter(Collider c) {
		if (c.gameObject.tag == "Bullet") {
			this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
			this.particleSystem.Play();
			//Destroy (this.gameObject);
			Destroy (c.gameObject);
			gcScript.xp += 1;
		}
	}
}
