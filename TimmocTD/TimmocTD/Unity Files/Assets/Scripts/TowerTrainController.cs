using UnityEngine;
using System.Collections;

public class TowerTrainController : MonoBehaviour {
	
	//Set up variables
	public float rotatespeed;
	public double[] movement;

	// Use this for initialization
	void Start () {
		movement = new double[]{.5,.5};
	}
	
	// Update function, update is called once per frame
	void Update () {
		
		//If left arrow is pressed
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
			movement [0] = 0;
			rotate (rotatespeed);
			
		}
		
		//If right arrow is pressed
		else if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
			movement [0] = 1;
			rotate (-rotatespeed);
			
		} else {
			movement[0] = .5;
		}

		//fire
		if (Input.GetKey (KeyCode.Space) || Input.GetKey (KeyCode.UpArrow)|| Input.GetKey (KeyCode.W)) {
			movement [1] = 1;
			Debug.Log ("Bang! Zoom! Straight to the moon!");
			
		} else {
			movement[1] = 0;
		}
	}
	
	public void rotate(float t) {
		transform.rotation = Quaternion.Euler(0, 0, getHeading() + t);
	}
	
	public void rotate(double t) {
		//Debug.Log (t);
		transform.rotation = Quaternion.Euler(0, 0, (float) t);
	}
	
	public float getHeading() {
		return transform.eulerAngles.z;
	}
}
