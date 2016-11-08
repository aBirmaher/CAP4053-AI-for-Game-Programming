using UnityEngine;
using System.Collections;
using System.IO;
using System.Linq;

public class NeuralNetworkTrainer {

	public int maxEpochs = 10000;
	public double errorThresh = 0.00001;
	public double learnRate = 1;
	public double momentum = 0.7;
	
	private GameObject player, target;
	private WallSensor wall;
	private PieSliceSensor pie;
	private AdjacentSensor adj;
	private CommitController ctrl;
	private NeuralNetwork nn;
	private double[] inputs, weights, outputs, targets;
	private int input = 3, output = 1, hidden = 4;
	private int numWeights, epoch, generation;
	private double error, finalError;

	private string outputFile = Application.dataPath + "/Datas/weights.txt";
	private string outputFile2 = Application.dataPath + "/Datas/weightsFinal.txt";

	public NeuralNetworkTrainer(GameObject player) {
		this.player = player;
		target = GameObject.Find ("timmoc");
		wall = this.player.GetComponent<WallSensor> ();
		//pie = GetComponent<PieSliceSensor> ();
		adj = this.player.GetComponent<AdjacentSensor> ();
		ctrl = this.player.GetComponent<CommitController> ();
		numWeights = (input * hidden) + (hidden * output) + (hidden + output);
		readWeights ();
		nn = new NeuralNetwork (input, output, hidden);
		nn.setWeights (weights);
		generation = 0;
	}

	public void train () {

		if (inputs == null || targets == null) {
			Debug.Log("Empty train set!");
			return;
		}

		Debug.Log ("Start Training.....");
		epoch = 0;
		error = double.MaxValue;


		while (epoch < maxEpochs) {
			if (epoch%20 == 0) {
				System.Console.Write(".");
			}
			outputs = nn.computeOutputs (inputs);
			error = NeuralNetworkHelpers.Error (targets, outputs);
			if (error < errorThresh) {
				System.Console.WriteLine("");
				Debug.Log ("Found weights and bias values that meet the error criterion at epoch " + epoch);
				break;
			}
			nn.backPropagate (targets, learnRate, momentum);
			epoch++;
		}
		this.weights = nn.getWeights ();
		//writeWeights ();

		this.outputs = nn.computeOutputs (inputs);
		System.Console.WriteLine("");
		Debug.Log ("Completed traning with: ");
		NeuralNetworkHelpers.printArray ("Inputs: ", this.inputs);
		NeuralNetworkHelpers.printArray ("Targets: ", this.targets);
		NeuralNetworkHelpers.printArray ("Outputs: ", this.outputs);
		Debug.Log ("Final Error: " + error);
	}

	public void setTargets(double[] incoming) {
		this.targets = new double[output];
		incoming.CopyTo (this.targets, 0);
		//normalize (targets, 360.0);
	}

	public void setInputs(double[] incoming) {
		this.inputs = new double[input];
		incoming.CopyTo (this.inputs, 0);
		//normalize (inputs, inputs.Max());
	}

	public double getError() {
		return this.finalError;
	}

	double[] getRandomWeights(int size) {
		System.Random rand = new System.Random ();
		double[] w = new double[size];
		for (int i = 0; i < size; i++) {
			w[i] = rand.NextDouble();
		}
		return w;
	}

	public double[] getInputs() {
		double[] tmp = new double[input];
		wall.getDistance ().CopyTo (tmp, 0);
		//normalize (tmp, tmp.Max());	// Normalize data, max number of data is the maximum range of wall sensor
		return tmp;
	}

	public double[] getTargets() {
		double[] tmp = new double[output];
		double range = wall.maxRange;
		double[] wdata = wall.getDistance ();
		double rotation = player.transform.eulerAngles.z + (((range - wdata[1]) / range) + wdata[0] - wdata[2]) * 10.0;
		if (wdata.Average() == range) {
			rotation = getAngle ();
		}
		tmp [0] = rotation;
		normalize (tmp, 1000.0);
		return tmp;
	}

	void normalize(double[] array, double max) {
		for (int i = 0; i < array.Length; i++) {
			array[i] /= max;
		}
	}
	
	//getAngle function
	public double getAngle() {
		double heading = ctrl.getHeading ();
		double relative = (double) adj.getAngle ();
		if (360.0 - relative >= 180.0 || relative == 360.0) {
			return (heading + relative) % 360.0;
		}
		return ((heading - 360.0 + relative) + 360.0) % 360.0;
	}

	public NeuralNetwork getNetwork() {
		return this.nn;
	}

	public WallSensor getWall() {
		return this.wall;
	}

	public CommitController getController() {
		return this.ctrl;
	}

	public GameObject getTarget() {
		return this.target;
	}

	void readWeights() {
		this.weights = new double[numWeights];
		if (File.Exists (@outputFile)) {
			Debug.Log("Found existed file");
			using (StreamReader reader = new StreamReader(@outputFile)) {
				for (int i = 0; i < this.weights.Length; i++) {
					this.weights[i] = System.Convert.ToDouble(reader.ReadLine());
				}
				reader.Close();
			}
		} else {
			Debug.Log("No existing files");
			this.weights = getRandomWeights (numWeights);
		}
	}

	public void writeWeights() {
			using (StreamWriter writer = new StreamWriter(new FileStream(@outputFile, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))) {
			foreach(double d in this.weights) {
				writer.WriteLine(d);
			}
		}
	}

	public void writeFinalWeights() {
		using (StreamWriter writer = new StreamWriter(new FileStream(@outputFile2, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))) {
			foreach(double d in this.weights) {
				writer.WriteLine(d);
			}
		}
	}

	public string toDebug() {
		return "Epoch: " + this.epoch + " Generation: " + this.generation;
	}
}
