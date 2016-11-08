using UnityEngine;
using System.Collections;
using System;

//WallSensor class
public class WallSensor : MonoBehaviour {

	//Variable Instantiation
	public float maxRange;
	private string res;
	private double[] distance;
	private int oSize = 3;
	private static double[] angles = {90.0, 45.0, 0.0, -45.0, -90.0, 180};
	
	// Use this for initialization
	void Start () {
		distance = new double[oSize];	// 0 : 90 degree 1: 45 degree	2 : 0 degree	3 : -45 degree	4 : -90 degree	5 : 180 degree
	}

	//FixedUpdate Function
	void Update() {
		RaycastHit2D hit = new RaycastHit2D ();
		res = "";
		for (int i = 0; i < oSize; i++) {
			distance[i] = casting(hit, angles[i+1]);
			res += distance[i]/maxRange + ",";
		}
		//Print value found above and stored in res
		//print (res);
	}

	double casting(RaycastHit2D hit, double angle) {
		hit = Physics2D.Raycast(transform.position, Quaternion.AngleAxis((float) angle, transform.forward) * transform.up, maxRange, 1<<8);
		if (hit.collider != null) {
			//Debug.Log("got hit");
			return Vector2.Distance (hit.point, transform.position);
		} else {
			return maxRange;
		}
	}

	//toString Function
	public string toString(){

		//Returns res value
		return res;

	}
	
	public double[] getDistance() {
		return distance;
	}
	
	public double[] getNormalizedDistance() {
		double[] normie = (double[])distance.Clone();
		normie[0] /= maxRange;
		normie[1] /= maxRange;
		normie[2] /= maxRange;
		return normie;
	}
}