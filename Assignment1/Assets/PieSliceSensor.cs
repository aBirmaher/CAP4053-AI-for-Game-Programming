using UnityEngine;
using System.Collections;

//PieSliceSensor class
public class PieSliceSensor : MonoBehaviour {
	
	//Variable Instantiation
	public float maxRange;
	public float frontAngle;
	public float supplementAngle;
	private string res="";
	private int front, back, left, right;
	
	// Use this for initialization
	void Start () {
		
		//Calculates angle
		supplementAngle = 180 - frontAngle;
		
	}
	
	//Fixed update function
	void FixedUpdate() {
		
		//Set value of front, back, left and right to 0
		front = back = left = right = 0;
		
		//Sets up RatcastHit2D object for use
		RaycastHit2D[] hits = Physics2D.CircleCastAll (transform.position, maxRange, transform.up, 0f, 1 << 9);

		//Checks for where the ray hits
		foreach (RaycastHit2D hit in hits) {

			//Find angle
			float angle = getAngle(hit);

			//Find angles 
			float topLeft = frontAngle / 2.0f;
			float topRight = 360.0f - frontAngle / 2.0f;
			float bottomLeft = topLeft + supplementAngle;
			float bottomRight = bottomLeft + frontAngle;

			// Right VOF
			if (angle <= topRight && angle >= bottomRight) 	
				right++;

			// Back VOF
			else if (angle >= bottomLeft && angle <= bottomRight) 	
				back++;

			// Left VOF
			else if (angle >= topLeft && angle <= bottomLeft)
				left++;
			 
			// Front VOF
			else	
				front++;

		}

		//Prints the values to console
		print (front + "," + left + "," + back + "," + right);

		//Sets the value of res for later printing to display
		res = front + "," + left + "," + back + "," + right;
	}

	//getAngle Function
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
		return res;
		
	}

}
