using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Threading;

public class Trainer {


	public class Stopper {
		public double errorThresh = 0.0001;
		public bool output = false;
		public bool stop = false;
		public Stopper() {
		}
		public void run() {
			while (true) {
				String outcmd = "";
				outcmd = Console.ReadLine();
				
				if(outcmd.Equals("o"))
					output = true;
				if (outcmd.Equals("s"))
					stop = true;
			}
		}
	}
	bool trained = false, read = false;
	ArrayList sets;
	Recorder rec;
	NeuralNetwork nn;
	int numWeights;
	private double[] inputs, weights, outputs, targets;
	private int input = 9, output = 2, hidden = 8;
	private string outputFile;
	public double error = 0;
	public double learnRate = .5;
	public double momentum = 0.25;
	public int ctr = 0;
	// Use this for initialization
	public void Start() {
		Stopper s = new Stopper(); 
		Console.WriteLine("How many hidden nodes?");
		hidden = int.Parse(Console.ReadLine());
		Console.WriteLine("Epoch counter?");
		int epochCtr = int.Parse(Console.ReadLine());
		Console.WriteLine("Error threshold?");
		s.errorThresh = float.Parse(Console.ReadLine());
		Thread oThread = new Thread(new ThreadStart(s.run));
		oThread.Start();
		String outPath = "C:/Users/SwoodGrommet/Desktop/game-ai/Assets/Scripts/Datas/";
		outputFile = "weights.txt";
		sets = new ArrayList();
		rec = new Recorder();
		nn = new NeuralNetwork (input, output, hidden);
		numWeights = (input * hidden) + (hidden * output) + (hidden + output);
		weights = getRandomWeights (numWeights);
		nn = new NeuralNetwork (input, output, hidden);
		nn.setWeights (weights);
		Console.WriteLine("chutzpah");
		rec.read (this.sets);
		read = true;
		double changeDel = 0;
		while (/*!trained &&*/ read) {
			double errors = 0;
			//do {
			foreach (TrainingSet set in this.sets) {
				setInputs(set.getInputs());
				setTargets(set.getTargets());
				errors += train();
			}

			//Debug.Log("Current error : " + errors);
			//} while (error > 0.0001);
			error = errors / sets.Count;
			if (s.output) {
				Console.WriteLine("Outputting weights to file");
				this.weights = nn.getWeights();
				nn.outputWeights(weights);
				s.output = false;
			}
			if (s.errorThresh > error || s.stop) {
				Console.WriteLine("All trainings are done!!!");
				break;
			}
			//Console.WriteLine(ctr + ": " + errors);
			if (ctr % epochCtr == 0) {
				Console.WriteLine("epoch: " + ctr / epochCtr + "; error: " + error + "; Delta: " + (changeDel - error));
				changeDel = error;
			}
			ctr++;
		}
		
	}
	
	
	public double train () {
		
		if (inputs == null || targets == null) {
			Console.WriteLine("Empty train set!");
			return -1;
		}
		
		//Console.WriteLine("Start Training.....");
		outputs = nn.computeOutputs (inputs);
		error = NeuralNetworkHelpers.Error (targets, outputs);
		nn.backPropagate (targets, learnRate, momentum);
		return error;
	}
	
	double[] getRandomWeights(int size) {
		System.Random rand = new System.Random ();
		double[] w = new double[size];
		for (int i = 0; i < size; i++) {
			w[i] = rand.NextDouble();
		}
		return w;
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
}

public class TrainingSet {
	
	double[] targets, inputs;
	
	public TrainingSet(double[] i, double[] t) {
		this.targets = t;
		this.inputs = i;
	}
	
	public double[] getTargets() {
		return this.targets;
	}
	
	public double[] getInputs() {
		return this.inputs;
	}
	
}