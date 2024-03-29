﻿using UnityEngine;
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
		//if (Application.platform == RuntimePlatform.IPhonePlayer) {
		if (TiltToMove() != 0) {
			xvel = TiltToMove() * turnSpeed;
		}
		//}
		if (xvel < 0 && this.transform.position.x <= -9.0f) {
			xvel = 0.0f;
		} else if (xvel > 0 && this.transform.position.x >= 9.0f) {
			xvel = 0.0f;
		}

		TiltToMove ();

		this.rigidbody.velocity = new Vector3(xvel, this.rigidbody.velocity.y, runSpeed);
		if (Input.GetButtonDown("Fire1")) {
			var bullet = Instantiate(bulletPrefab) as Transform;
			bullet.GetComponent<BulletScript>().ShootFrom(this.transform);
			//bullet.parent = this.transform;
		}

		levelUpParticles.transform.position = this.transform.position;
	}

	int TiltToMove() {
		float tiltAngle = iPhoneInput.acceleration.x;
		Debug.Log (tiltAngle.ToString());

		if (Mathf.Abs (tiltAngle) > 0.1f) {
			if (tiltAngle < 0) {
				return -1;
			}  else if (tiltAngle > 0) {
				return 1;
			}
		}
		return 0;
	}

	void OnTriggerEnter(Collider c) {
		if (c.gameObject.tag == "Wall") {
			gcScript.HurtPlayer();
			Destroy (c.gameObject);
		}

		if (c.gameObject.tag == "Exit") {
			int completedStages = PlayerPrefs.GetInt ("CompletedStages");
			if (gcScript.stage > PlayerPrefs.GetInt ("CompletedStages")) {
				PlayerPrefs.SetInt ("CompletedStages", gcScript.stage);
			}
			gcScript.SaveProgress();
			PlayerPrefs.Save ();
			Application.LoadLevel("stageselect");
        }

		if (c.gameObject.tag == "Potion") {
			gcScript.HealPlayer();
			Destroy (c.gameObject);
		}
    }

	public void Die() {
		this.rigidbody.velocity = Vector3.zero;
		this.gameObject.particleSystem.Play();
		this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
		alive = false;
		StartCoroutine(WaitThenQuit());
	}

	public void LevelUp() {
		levelUpParticles.Play();
	}

	IEnumerator WaitThenQuit() {
		yield return new WaitForSeconds(3.0f);
		gcScript.SaveProgress();
		Application.LoadLevel ("stageselect");
	}
}
