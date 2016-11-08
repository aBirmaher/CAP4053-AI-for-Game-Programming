using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.IO;
using System.Linq;

public class Trainer : MonoBehaviour {

    public static double learnRate = 1;
    public static double momentum = 0.7;

    public GameObject message;
	
    private int input = NeuralNetworkHelpers.inputNode;
    private int output = NeuralNetworkHelpers.outputNode;
    private int hidden = NeuralNetworkHelpers.hiddenNode;
    private int numWeights;
    private long generation;
    private double[] weights;
    private double error;
    private bool trained;
    private Recorder rec;
    private NeuralNetwork nn;
    private string outputFile;
    private ArrayList trainingSets;

	
	// Use this for initialization
	void Start () {
		this.outputFile = Application.dataPath + "/Datas/weights.txt";
        this.numWeights = (input * hidden) + (hidden * output) + (hidden + output);
        this.weights = NeuralNetworkHelpers.getRandomWeights (numWeights);
		this.nn = new NeuralNetwork (input, output, hidden);
		this.nn.setWeights (weights);
        this.error = double.MaxValue;
        this.trained = false;
        this.rec = new Recorder();
        this.trainingSets = this.rec.read(input, output);
	}
	
	// Update is called once per frame
	void Update () {
        if (this.error > 0) {
            this.error = train();
            backProp();
            this.weights = this.nn.getWeights();
            this.generation++;
            this.message.GetComponent<Text>().text = "Training in progress...\n" +
                                                    "Input Size: " + this.input + "\t\tOutput Size: " + this.output + "\n" +
                                                    "Current Tranining Size: " + this.trainingSets.Count + "\n" +
                                                    "Current Generation: " + this.generation + "\n" +
                                                    "Current Error: " + Math.Round(this.error, 5) + "\t\tAverage Error: " + Math.Round(this.error/this.trainingSets.Count, 5) + "\n" +
                                                    "Press 'Stop Training' to stop...";
        } else {
            error = -1;
            this.message.GetComponent<Text>().color = Color.red;
            this.message.GetComponent<Text>().text = "Error: Empty training set!!!!!!!\n" +
                "Press 'Stop Training' to stop...";
        }
	}
	
	public double train () {
		
        if (this.trainingSets.Count == 0 || this.trainingSets == null) {
            Debug.Log("Empty training set!");
            return -1;
        }

        ArrayList oList = new ArrayList (); // pile up datas for error calculation
        ArrayList tList = new ArrayList ();
		
        foreach (NeuralNetworkTrainingSet set in this.trainingSets) {
            double[] inputs = set.getInputs();
            double[] targets = set.getTargets();
            double[] outputs = this.nn.computeOutputs(inputs);
            for (int i = 0; i < outputs.Length; i++) {
                oList.Add(outputs[i]);
                tList.Add(targets[i]);
            }
        }
        return NeuralNetworkHelpers.Error ((double[]) tList.ToArray(typeof(double)), (double[]) oList.ToArray(typeof(double)));
	}

    private void backProp() {
        foreach (NeuralNetworkTrainingSet set in this.trainingSets) {
            this.nn.computeOutputs(set.getInputs());
            this.nn.backPropagate(set.getTargets(), learnRate, momentum);
        }
    }

    public double getError() {
        return this.error;
    }

    public long getGeneration() {
        return this.generation;
    }

    public void writeWeights(string name) {
        this.message.GetComponent<Text>().text = "";
        NeuralNetworkHelpers.writeWeights(name, this.weights);
    }
}