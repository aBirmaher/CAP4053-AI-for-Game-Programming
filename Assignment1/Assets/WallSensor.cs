using UnityEngine;
using System.Collections;
using System;

//WallSensor class
public class WallSensor : MonoBehaviour {

	//Variable Instantiation
	public float maxRange;
	private string res;
	
	// Use this for initialization
	void Start () {
		
	}

	//FixedUpdate Function
	void FixedUpdate() {

		//Create RaycastHit2D object and calculate hit value for checking
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Quaternion.AngleAxis(45f, transform.forward) * transform.up, maxRange, 1<<8);

		//If something is in range and is hit
		if (hit.collider != null) {

			//Message to print is distance rounded to 2 decimal places
			res = Math.Round(Vector2.Distance(hit.point,transform.position),2) + ",";

		} 

		//If nothing is in range
		else {

			//Set value of res for printing to max range
			res = maxRange + ",";
		}

		//Calculate hit value for checking
		hit = Physics2D.Raycast(transform.position, transform.up, maxRange, 1<<8);

		//If something is hit
		if (hit.collider != null) {

			//Add distance of object rounded to 2 decimal places to message to display
			res += Math.Round(Vector2.Distance (hit.point, transform.position),2) + ",";
		} 

		//If nothing is hit
		else {

			//Set value of res for printing to max range
			res += maxRange + ",";

		}

		//Calculate hit value for checking
		hit = Physics2D.Raycast(transform.position, Quaternion.AngleAxis(-45f, transform.forward) * transform.up, maxRange, 1<<8);

		//If something is hit
		if (hit.collider != null) {

			//Add distance of object rounded to 2 decimal places to message to display
			res += Math.Round(Vector2.Distance (hit.point, transform.position),2);
		
		} 

		else {

			//Set value of res for printing to max range
			res += maxRange;

		}

		//Print value found above and stored in res
		print (res);
	}

	//toString Function
	public string toString(){

		//Returns res value
		return res;

	}
}