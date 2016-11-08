using UnityEngine;
using System.Collections;
using System.IO;

public class NeuralNetworkTrainingSet {
    
    double[] targets, inputs, outputs;
    
    public NeuralNetworkTrainingSet(double[] i, double[] t) {
        this.targets = t;
        this.inputs = i;
    }
    
    public void setOutputs(double[] o) {
        this.outputs = o;
    }
    
    public double[] getTargets() {
        return this.targets;
    }
    
    public double[] getInputs() {
        return this.inputs;
    }
    
    public double[] getOutput() {
        return this.outputs;
    }
    
}
