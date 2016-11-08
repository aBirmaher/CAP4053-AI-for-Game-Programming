using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed;
	public float timeToDestroyBullet; // Set it in Unity Editor
	float firedTime;
	private bool hasTarget;
	private GameObject target;
	private Vector3 dir;

	// Use this for initialization
	void Start () {
		hasTarget = false;
		firedTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > firedTime + timeToDestroyBullet) {
			aoe();
		}
	}

	private void aoe() {
		Destroy (this.gameObject);
		Debug.Log ("BOOOOOOOOOOOOOOOOOOOOOOOOOOOM");
	}

	public void setTarget(GameObject target) {
		this.target = target;
		dir = target.transform.position - this.transform.position;
		dir.Normalize ();
		rigidbody2D.velocity = dir * speed;
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "timmoc") {
			//Dtestroy (this.gameObject);
			hasTarget = false;
			Debug.Log("Killed!");
		}
	}
}
