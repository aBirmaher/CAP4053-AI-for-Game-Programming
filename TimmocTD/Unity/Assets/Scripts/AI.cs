using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

	GameObject player, timmoc;
	CommitController ctrl;
	PieSliceSensor pie;
	WallSensor wall;
	NeuralNetwork net;
	AdjacentSensor adj;
	bool pause = false;
	bool run = false;
	bool once = false;
	double[] outputs;
	Vector3 pos;
	float timer;

	// Use this for initialization
	void Start () {
		pos = transform.position;
		player = GameObject.Find ("Commit");
		outputs = new double[2];
		net = new NeuralNetwork (9, 2, 6);
		net.readWeights ();
		ctrl = player.GetComponent<CommitController> ();
		wall = player.GetComponent<WallSensor> ();
		adj = player.GetComponent<AdjacentSensor> ();
		pie = player.GetComponent<PieSliceSensor> ();
	}
	
	// Update is called once per frame
	void Update () {
		outputs = net.computeOutputs (getInput ());
		//Turn Left
		if (outputs [0] < .4) {
			ctrl.rotate (ctrl.rotatespeed);

		} 
		//Turn Right
		else if (outputs [0] > .6) {
			ctrl.rotate (-ctrl.rotatespeed);
		} 

		//Move Forward
		if (outputs [1] < .5) {
						ctrl.move (-ctrl.movespeed);
				} 
		//Move Backward
		else if (outputs [1] > .5) {
						ctrl.move (ctrl.movespeed);
		} 
	}
	double[] getInput(){
		double[] inputs = new double[9];
		wall.getNormalizedDistance ().CopyTo (inputs, 0);
		inputs [3] = adj.getDistance ();
		inputs [4] = adj.getAngle();
//		inputs [5] = pie.front;
//		inputs [6] = pie.back;
//		inputs [7] = pie.left;
//		inputs [8] = pie.right;
		return inputs;
	}
	void OnTriggerEnter2D( Collider2D other) {
		pause = true;
		if (other.gameObject.tag == "wall") {
			//retrain();
			//transform.position = pos;
		} else if (other.gameObject == timmoc) {
			//retrain();
		}
		pause = false;
	}
}
