using System;
using System.Collections;
using System.IO;
using System.Linq;

public class NeuralNetwork {

	private int inputSize, outputSize, hiddenSize, weightSize;
	private double[][] ihWeights, hoWeights;
	private double[] inputs, hBiases, hSums, hOutputs;	// input-to-hidden
	private double[] oBiases, oSums, outputs;	// hidden-to-output
	
	private double[] hGrads;	// hidden gradients for back-propagation
	private double[] oGrads;	// output gradients for back-propagation
	
	private double[][] ihPrevWeightsDelta;  // for momentum with back-propagation
	private double[] hPrevBiasesDelta;
	private double[][] hoPrevWeightsDelta;
	private double[] oPrevBiasesDelta;

	public NeuralNetwork(int i, int o, int h) {
		this.inputSize = i;
		this.outputSize = o;
		this.hiddenSize = h;
		this.weightSize = i * h + h * o + h + o;
		
		ihWeights = NeuralNetworkHelpers.MakeMatrix (i, h);
		inputs = new double[i];
		hBiases = new double[h];
		hSums = new double[h];
		hOutputs = new double[h];
		
		hoWeights = NeuralNetworkHelpers.MakeMatrix (h, o);
		oBiases = new double[o];
		oSums = new double[o];
		outputs = new double[o];
		
		hGrads = new double[h];
		oGrads = new double[o];
		
		ihPrevWeightsDelta = NeuralNetworkHelpers.MakeMatrix(i, h);
		hPrevBiasesDelta = new double[h];
		hoPrevWeightsDelta = NeuralNetworkHelpers.MakeMatrix(h, o);
		oPrevBiasesDelta = new double[o];
	}
	
	private string outputFile = "weights.txt";
	
	public void readWeights() {
		
		double[] readStartWeights = new double[this.weightSize];
		if (File.Exists (@outputFile)) {
			Console.WriteLine("Found existed file");
			using (StreamReader reader = new StreamReader(@outputFile)) {
				for (int i = 0; i < readStartWeights.Length; i++) {
					readStartWeights[i] = System.Convert.ToDouble(reader.ReadLine());
				}
				reader.Close();
			}
			setWeights(readStartWeights);
		} else {
			Console.WriteLine("No existing files");
		}
	}

	public void setWeights(double[] weights) {
		if (weights.Length != this.weightSize) {
			throw new Exception("The weights array length: " + weights.Length +
			                    " does not match the total number of weights and biases: " + this.weightSize);
		}
		
		int k = 0;
		for (int i = 0; i < this.inputSize; i++) {
			for (int j = 0; j < this.hiddenSize; j++) {
				this.ihWeights[i][j] = weights[k++];
			}
		}
		for (int i = 0; i < this.hiddenSize; i++) {
			this.hBiases[i] = weights[k++];
		}
		for (int i = 0; i < this.hiddenSize; ++i) {
			for (int j = 0; j < this.outputSize; ++j) {
				this.hoWeights[i][j] = weights[k++];
			}
		}
		for (int i = 0; i < this.outputSize; ++i) {
			this.oBiases [i] = weights [k++];
		}
	}

	public double[] getWeights() {
		double[] res = new double[this.weightSize];
		int k = 0;
		for (int i = 0; i < this.ihWeights.Length; ++i) {
			for (int j = 0; j < this.ihWeights[0].Length; ++j) {
				res [k++] = this.ihWeights [i] [j];
			}
		}
		for (int i = 0; i < this.hBiases.Length; ++i) {
			res [k++] = this.hBiases [i];
		}
		for (int i = 0; i < this.hoWeights.Length; ++i) {
			for (int j = 0; j < this.hoWeights[0].Length; ++j) {
				res [k++] = this.hoWeights [i] [j];
			}
		}
		for (int i = 0; i < this.oBiases.Length; ++i) {
			res [k++] = this.oBiases [i];
		}
		return res;
	}

	public double[] getOutputs()
	{
		double[] res = new double[this.outputSize];
		this.outputs.CopyTo(res, 0);
		return res;
	}
	
	public double[] computeOutputs(double[] input) {
		if (input.Length != this.inputSize) {
			throw new Exception("Inputs array length " + this.inputs.Length + " does not match NN inputSize value " + this.inputSize);
		}
		
		for (int i = 0; i < this.hiddenSize; i++) {
			this.hSums[i] = 0.0;
		}
		for (int i = 0; i < this.outputSize; i++) {
			this.oSums[i] = 0.0;
		}
		for (int i = 0; i < input.Length; i++) {
			this.inputs[i] = input[i];	// Copy input to NN inputs
		}
		for (int j = 0; j < this.hiddenSize; j++) {
			for (int i = 0; i < this.inputSize; i++) {
				this.hSums[j] += this.inputs[i] * this.ihWeights[i][j];	// compute hidden layer weighted sums
			}
		}
		for (int i = 0; i < this.hiddenSize; i++) {
			this.hSums [i] += this.hBiases [i];	// add biases to hideen sums
		}
		for (int i = 0; i < this.hiddenSize; i++) {
			this.hOutputs[i] = hyperTan(this.hSums[i]);	// apply tanh activation
			//this.hOutputs[i] = sigmoid(this.hSums[i]);	// apply log-sigmoid activation
		}
		for (int j = 0; j < this.outputSize; j++) {
			for (int i = 0; i < this.hiddenSize; i++) {
				this.oSums[j] += this.hOutputs[i] * this.hoWeights[i][j];	// compute output layer weighted sums
			}
		}
		for (int i = 0; i < this.outputSize; i++) {
			this.oSums[i] += this.oBiases[i];	// add biases to output sums
		}
		for (int i = 0; i < this.outputSize; i++) {
			this.outputs[i] = sigmoid(this.oSums[i]);	// apply log-sigmoid activation
		}
		
		double[] res = new double[this.outputSize];	// for convenience when call method
		this.outputs.CopyTo (res, 0);
		return res;
	}
	
	public void backPropagate(double[] target, double learn, double mom) {
		// assumes that SetWeights and ComputeOutputs have been called and so inputs and outputs have values
		if (target.Length != this.outputSize) {
			throw new Exception ("target values not same Length as output in UpdateWeights");
		}
		
		// 1. compute output gradients. assumes log-sigmoid!
		for (int i = 0; i < this.oGrads.Length; i++) {
			double d = (1 - this.outputs[i]) * this.outputs[i];	// derivative of log-sigmoid is y(1-y)
			this.oGrads[i] = d * (target[i] - this.outputs[i]);	// oGrad = (1 - O)(O) * (T - O)
		}
		
		// 2. compute hidden gradients. assumes tanh!
		for (int i = 0; i < this.hGrads.Length; i++) {
			double d = (1 - this.hOutputs[i]) * (1 + this.hOutputs[i]);	// derivative of tanh is (1-y)(1+y)
			double s = 0.0;
			for (int j = 0; j < this.outputSize; j++) {	// each hidden delta is the sum of outputSize terms
				s += this.oGrads[j] * this.hoWeights[i][j];	// each downstream gradient * outgoing weight
			}
			this.hGrads[i] = d * s;	// hGrad = (1 - O)(1 + O) * E(oGrads * oWts)
		}

		// 2.1 compute hidden gradients. assumes log-sigmoid!
		/*
		for (int i = 0; i < this.hGrads.Length; i++) {
			double d = (1 - this.hOutputs[i]) * this.hOutputs[i];	// derivative of log-sigmoid is y(1-y)
			double s = 0.0;
			for (int j = 0; j < this.outputSize; j++) {	// each hidden delta is the sum of outputSize terms
				s += this.oGrads[j] * this.hoWeights[i][j];	// each downstream gradient * outgoing weight
			}
			this.hGrads[i] = d * s;	// hGrad = (1 - O)(O) * E(oGrads * oWts)
		}
		*/
		
		// 3. update input to hidden weights ( gradients mush be computed right-to-left but weights can be updated in any order)
		for (int i = 0; i < this.ihWeights.Length; i++) {	// 0..2 (3)
			for (int j = 0; j < this.ihWeights[0].Length; j++) {	// 0..3 (4)
				double d = learn * this.hGrads[j] * this.inputs[i];	// compute the new delta = 'eta * hGrad *input'
				this.ihWeights[i][j] += d;	// update
				this.ihWeights[i][j] += mom * this.ihPrevWeightsDelta[i][j];	// add momentum using previsou delta, on first pass old value will be 0.0 but that's ok.
				this.ihPrevWeightsDelta[i][j] = d;	// save the delta for next time
			}
		}
		
		// 4. update hidden biases
		for (int i = 0; i < this.hBiases.Length; i++) {
			double d = learn * this.hGrads[i] * 1.0;	// the 1.0 is the constant input for any bias; could leave out
			this.hBiases[i] += d;
			this.hBiases[i] += mom * this.hPrevBiasesDelta[i];
			this.hPrevBiasesDelta[i] = d;	// save delta
		}
		
		// 5. update hideen to output weights
		for (int i = 0; i < this.hoWeights.Length; i++) {
			for (int j = 0; j < this.hoWeights[0].Length; j++) {
				double d = learn * this.oGrads[j] * this.hOutputs[i];	// hOutputs are inputs to next layer
				this.hoWeights[i][j] += d;
				this.hoWeights[i][j] += mom * this.hoPrevWeightsDelta[i][j];
				this.hoPrevWeightsDelta[i][j] = d;
			}
		}
		
		// 6. update hidden to output biases
		for (int i = 0; i < this.oBiases.Length; i++) {
			double d = learn * this.oGrads[i] * 1.0;
			this.oBiases[i] += d;
			this.oBiases[i] += mom * this.oPrevBiasesDelta[i];
			this.oPrevBiasesDelta[i] = d;
		}
	}
	public void outputWeights(double[] weights){
		using (StreamWriter writer = new StreamWriter(new FileStream(@outputFile, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))) {
			foreach(double d in weights) {
				writer.WriteLine(d );
			}
		}
	}
	private static double sigmoid(double x) {
		if (x < -45.0)
			return 0.0;
		else if (x > 45.0)
			return 1.0;
		else
			return 1.0 / (1.0 + Math.Exp (-x));
	}
	
	private static double hyperTan(double x) {
		if (x < -45.0)
			return -1.0;
		else if (x > 45.0)
			return 1.0;
		else
			return Math.Tanh(x);
	}
}
