using UnityEngine;
using System.Collections;

//Move class
public class Mover : MonoBehaviour {

	//Set up variables
	public float movespeed;
	private float theta = 90;
	
	// Use this for initialization
	void Start () {
	
	}

	// Update function, update is called once per frame
	void Update () {

		//If left arrow is pressed
		if( Input.GetKey(KeyCode.LeftArrow) ) {

			//Shift angle
			theta+= 5;
			transform.rotation = Quaternion.Euler(0, 0, theta - 90);

		}

		//If right arrow is pressed
		else if( Input.GetKey(KeyCode.RightArrow) ) {

			//Shift angle
			theta -= 5;
			transform.rotation = Quaternion.Euler(0, 0, theta - 90);

		}

		//If up arrow is pressed
		if( Input.GetKey(KeyCode.UpArrow) ) {

			//Move forward
			transform.position += transform.up * .05f;

		}

		//If down arrow is pressed
		else  if( Input.GetKey(KeyCode.DownArrow) ) {

			//Move backwards
			transform.position += transform.up * -.05f;

		}	

	}

	//FixedUpdaye Function
	void FixedUpdate() {

		//Prints info to console
		print (transform.position + " " + (theta = theta%360));

	}

}