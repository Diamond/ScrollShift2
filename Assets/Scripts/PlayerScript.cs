using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public GameControllerScript gcScript;
	public float     runSpeed      = 10.0f;
	public float     turnSpeed     = 5.0f;
	public bool      alive         = true;
	public Transform bulletPrefab;
	public ParticleSystem levelUpParticles;

	void Start() {
		gcScript = GameObject.Find ("GameController").GetComponent<GameControllerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!alive) return;

		float xvel = Input.GetAxis("Horizontal") * turnSpeed;
		if (xvel < 0 && this.transform.position.x <= -9.0f) {
			xvel = 0.0f;
		} else if (xvel > 0 && this.transform.position.x >= 9.0f) {
			xvel = 0.0f;
		}

		this.rigidbody.velocity = new Vector3(xvel, this.rigidbody.velocity.y, runSpeed);
		if (Input.GetButtonDown("Fire1")) {
			var bullet = Instantiate(bulletPrefab) as Transform;
			bullet.GetComponent<BulletScript>().ShootFrom(this.transform);
			//bullet.parent = this.transform;
		}

		levelUpParticles.transform.position = this.transform.position;
	}

	void OnTriggerEnter(Collider c) {
		if (c.gameObject.tag == "Wall") {
			gcScript.HurtPlayer(1);
			Destroy (c.gameObject);
		}

		if (c.gameObject.tag == "Exit") {
			Application.LoadLevel("prototype");
        }
    }

	public void Die() {
		this.rigidbody.velocity = Vector3.zero;
		this.gameObject.particleSystem.Play();
		this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
		alive = false;
	}

	public void LevelUp() {
		levelUpParticles.Play();
	}

	IEnumerator WaitThenQuit() {
		yield return null;
		for (float f = 1f; f >= 0; f -= 0.1f) {
			Color c = renderer.material.color;
			c.a = f;
			renderer.material.color = c;

		}
	}
}
