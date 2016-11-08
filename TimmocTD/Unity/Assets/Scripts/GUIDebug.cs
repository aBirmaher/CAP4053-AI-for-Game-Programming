using UnityEngine;
using System.Collections;

//GUIDebug class
public class GUIDebug : MonoBehaviour {

	//Variable instantiation
	private Texture2D blackTexture;
	GameObject commit;
	PieSliceSensor pie;
	WallSensor wall;
	AdjacentSensor adj;
	AI ai;

	// Use this for initialization
	void Start () {

		//Get sensor info for printing
		commit = GameObject.Find ("Commit");
		pie = commit.GetComponent<PieSliceSensor>();
		wall = commit.GetComponent<WallSensor>();
		adj = commit.GetComponent<AdjacentSensor>();
		ai = commit.GetComponent<AI> ();
	}

	//For showing in GUI
    void OnGUI () {

		//Places GUI objects in their locations and provides info to fill them
		GUI.Box(new Rect(10,10,300,190), "Debug");
		GUI.Label(new Rect(20,30,300,180),  "Position: " + commit.transform.position + " " + commit.transform.eulerAngles.z);
		GUI.Label(new Rect(20,50,300,180),  "Pie : " + pie.toString());
		GUI.Label(new Rect(20,70,300,180),  "Wall: " + wall.toString());
		GUI.Label(new Rect(20,90,300,180),  "Adj : " + adj.toString());


		//Debug.Log (wall.toString ());
//		GUI.Label(new Rect(20,110,300,180),  ai.toDebug ());
//		GUI.Label(new Rect(20,130,300,180), "Input: " + ai.getInputString ());
//		GUI.Label(new Rect(20,150,300,180), "Output: " + ai.getOutputString ());
//		GUI.Label(new Rect(20,170,300,180),  "Target Angle : " + ai.getAngle());

	}

}