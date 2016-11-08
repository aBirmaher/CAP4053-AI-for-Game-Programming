using UnityEngine;
using System.Collections;
using System;

//AdjacentSensor class
public class AdjacentSensor : MonoBehaviour {

	//Variable Instantiation
	public float maxRadius;
	private string res_s;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update function, update is called once per frame
	void FixedUpdate () {

		//Sets up RatcastHit2D object for use
		RaycastHit2D[] hits = Physics2D.CircleCastAll (transform.position, maxRadius, transform.up, 0f, 1 << 9);

		//Starts putting things in res_s
		res_s = "[";

		//For each hit
		foreach (RaycastHit2D hit in hits) {

			//Calculations of distance and angle
			float distance = (float)Math.Round(Vector2.Distance(hit.point, transform.position),2);
			float angle = (float)Math.Round(getAngle(hit),2);

			//Add info to res_s for printing
			res_s += "(" + distance + ", " + angle + "),";

		}

		//If res_s is longer than 1, remove length-1
		if (res_s.Length > 1) res_s = res_s.Remove (res_s.Length - 1);

		//Last thing to print in res_s
		res_s += "]";

		//Prints whats in res_s to console
		print (res_s);

	}

	//getAngle function
	float getAngle(RaycastHit2D hit) {

		//Collects information
		Vector3 to = hit.collider.transform.position - transform.position;
		
		//Calculates angle
		float angle = Vector2.Angle(transform.up, to.normalized);
		
		//Cross product
		Vector3 cross = Vector3.Cross (transform.up, to);
		
		//If the cross is between certain angles bring down the angle by 360
		if (cross.z < 0) angle -= 360;
		
		//Return the absolute value of the angle
		return Mathf.Abs(angle);

	}

	//toString Function
	public string toString(){
		
		//Returns res value
		return res_s;
		
	}

}
