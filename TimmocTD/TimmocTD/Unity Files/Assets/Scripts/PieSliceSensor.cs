using UnityEngine;
using System.Collections;
using System.Linq;

//PieSliceSensor class
public class PieSliceSensor : MonoBehaviour {

	public static float angle = 45f;
	
	//Variable Instantiation
<<<<<<< HEAD
	private float maxRange;
    private double[] quadrant;
=======
	public float maxRange;

	private int[] quadrant;
>>>>>>> cd3c54cdc1382c9281f8215a0e5df8fe489c3d23
	private float[] angleHeadings;
	
	// Use this for initialization
	void Start () {
		//Calculates angle
<<<<<<< HEAD
        maxRange = gameObject.GetComponent<Tower>().attackRange;
		quadrant = new double[] {0,0,0,0,0,0,0,0};
=======
		quadrant = new int[] {0,0,0,0,0,0,0,0};
>>>>>>> cd3c54cdc1382c9281f8215a0e5df8fe489c3d23
		angleHeadings = new float[] {22.5f, 337.5f,
									 292.5f, 247.5f,
									 202.5f, 157.5f,
									 112.5f, 67.5f};
	}

	//Fixed update function
	void FixedUpdate() {

		//Sets up RatcastHit2D object for use
		RaycastHit2D[] hits = Physics2D.CircleCastAll (transform.position, maxRange, transform.up, 0f, 1 << 10);
<<<<<<< HEAD
		quadrant = new double[] {0,0,0,0,0,0,0,0};
=======
		quadrant = new int[] {0,0,0,0,0,0,0,0};
>>>>>>> cd3c54cdc1382c9281f8215a0e5df8fe489c3d23
		//Checks for where the ray hits
		foreach (RaycastHit2D hit in hits) {

			//Find angle
			float angle = getAngle(hit);
			if (angle <= angleHeadings[0] && angle >= 0f || angle <= 360f && angle >= angleHeadings[1]) {	// Quad 0
				quadrant[0]++;
			} else if (angle <= angleHeadings[1] && angle >= angleHeadings[2]) {	// Quad 1
				quadrant[1]++;
			} else if (angle <= angleHeadings[2] && angle >= angleHeadings[3]) {	// Quad 2
				quadrant[2]++;
			} else if (angle <= angleHeadings[3] && angle >= angleHeadings[4]) {	// Quad 3
				quadrant[3]++;
			} else if (angle <= angleHeadings[4] && angle >= angleHeadings[5]) { 	// Quad 4
				quadrant[4]++;
			} else if (angle <= angleHeadings[5] && angle >= angleHeadings[6]) {	// Quad 5
				quadrant[5]++;
			} else if (angle <= angleHeadings[6] && angle >= angleHeadings[7]) {	// Quad 6
				quadrant[6]++;
			} else if (angle <= angleHeadings[7] && angle >= angleHeadings[0]) {	// Quad 7
				quadrant[7]++;
			}

		}
		//Prints the values to console
<<<<<<< HEAD
//		Debug.Log (toString());
=======
		//Debug.Log (toString());
>>>>>>> cd3c54cdc1382c9281f8215a0e5df8fe489c3d23
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
	public double[] getNormQuadrant(){
		double[] tmp = new double[quadrant.Length];
<<<<<<< HEAD
		double max = quadrant.Max ();
        if (max == 0)
            return quadrant;
		for (int i = 0; i < tmp.Length; i++) {
			tmp[i] = quadrant[i] / max;
=======
		int max = quadrant.Max ();
		for (int i = 0; i <= tmp.Length; i++) {
			tmp[i] = (double) quadrant[i] / max;
>>>>>>> cd3c54cdc1382c9281f8215a0e5df8fe489c3d23
		}
		return tmp;
	}
	//toString Function
	public string toString(){

		string res = "";
<<<<<<< HEAD
        for (int i = 0; i < quadrant.Length; i++) {
            res += quadrant[i] + ",";
		}
		//Returns res value
		return res;
		
	}

	public string toRecordString(double[] array){
		
=======
		for (int i = 0; i < quadrant.Length; i++) {
			res += quadrant[i] + ",";
		}
		//Returns res value
		return res;
		
	}

	public string toRecordString(double[] array){
		
>>>>>>> cd3c54cdc1382c9281f8215a0e5df8fe489c3d23
		string res = "";
		for (int i = 0; i < array.Length; i++) {
			res += array[i] + ",";
		}
		//Returns res value
		return res;
		
	}

}
