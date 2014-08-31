using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
	public float    bulletSpeed = 20.0f;
	public float    range       = 25.0f;
	public bool     alive       = false;

	private Vector3 _startPosition;

	// Use this for initialization
	void Start () {
		ShootFrom(this.transform);
	}
	
	// Update is called once per frame
	void Update () {
		if (alive) {
			if (Mathf.Abs(this.transform.position.z - _startPosition.z) < range) {
				this.transform.position += new Vector3(0.0f, 0.0f, bulletSpeed * Time.deltaTime);
			} else {
				alive = false;
				this.renderer.enabled = false;
				// TODO: Recycle instead of destroying
				Destroy (this.gameObject);
			}
		}
	}

	public void ShootFrom(Transform origin) {
		_startPosition = origin.position;
		this.transform.position = _startPosition;
		alive = true;
		this.renderer.enabled = true;
	}
}
