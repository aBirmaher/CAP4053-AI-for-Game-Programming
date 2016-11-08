using UnityEngine;
using System.Collections;

//GUIDebug class
public class GUIDebug : MonoBehaviour {

	//Variable instantiation
	private Texture2D blackTexture;
	PieSliceSensor pie;
	WallSensor wall;
	AdjacentSensor adj;

	// Use this for initialization
	void Start () {

		//Get sensor info for printing
		pie = gameObject.GetComponent<PieSliceSensor>();
		wall = gameObject.GetComponent<WallSensor>();
		adj = gameObject.GetComponent<AdjacentSensor>();
	
	}

	//For showing in GUI
    void OnGUI () {

		//Places GUI objects in their locations and provides info to fill them
		GUI.Box(new Rect(10,10,300,140), "Debug");
		GUI.Label(new Rect(20,30,300,180),  "Position: " + transform.position);
		GUI.Label(new Rect(20,50,300,180),  "Pie : " + pie.toString());
		GUI.Label(new Rect(20,70,300,180),  "Wall: " + wall.toString());
		GUI.Label(new Rect(20,90,300,180),  "Adj : " + adj.toString());
  
	}

}