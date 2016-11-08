using UnityEngine;
using System.Collections;

public class TowerController : MonoBehaviour {

	public float rotateSpeed = 5.0f;

	private bool hasMoved;
	public double[] movement;
	private GameObject tower;


	// Use this for initialization
	void Start () {
		movement = new double[] {.5 ,.5};
		tower = GameObject.FindGameObjectWithTag ("tower");
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
			movement [0] = 0;
			hasMoved = true;
			rotate (rotateSpeed);
			
		} else if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
			movement [0] = 1;
			hasMoved = true;
			rotate (-rotateSpeed);
		} else {
			movement[0] = .5;
		}

		if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.Space)) {
			movement [1] = 1;
			hasMoved = true;
			fire();
		} else {
			movement[1] = 0;
		}


	}

	public void fire() {
		tower.GetComponent<TowerShooter> ().fire ();
	}

	public void rotate(float t) {
		transform.rotation = Quaternion.Euler(0, 0, getHeading() + t);
	}
	
	public void rotate(double t) {
		transform.rotation = Quaternion.Euler(0, 0, (float) t);
	}

	public float getHeading() {
		return transform.eulerAngles.z;
	}
}
