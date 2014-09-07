using UnityEngine;
using System.Collections;

public class PotionScript : MonoBehaviour {
	public float bounceVel = 1.0f;

	void Start() {
		this.rigidbody.velocity += new Vector3(0.0f, bounceVel, 0.0f);
	}

	void Update() {
		if (this.rigidbody.velocity.y <= 0.5f && this.rigidbody.velocity.y >= -0.5f) {
			this.rigidbody.velocity = new Vector3(this.rigidbody.velocity.x, 0.0f, this.rigidbody.velocity.z);
			bounceVel *= -1;
			this.rigidbody.velocity += new Vector3(0.0f, bounceVel, 0.0f);
		}
	}
}
