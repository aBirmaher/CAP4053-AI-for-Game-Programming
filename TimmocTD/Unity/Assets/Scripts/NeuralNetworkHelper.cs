using UnityEngine;
using System.IO;
using System.Collections;

public class NeuralNetworkHelpers {

    public static int inputNode = 9;
    public static int outputNode = 2;
    public static int hiddenNode = 5;

	public static double[][] MakeMatrix(int rows, int cols)
	{
		double[][] result = new double[rows][];
		for (int i = 0; i < rows; ++i)
			result[i] = new double[cols];
		return result;
	}

    public static double Error(double[] t, double[] o) {
        double s = 0.0;
        for (int i = 0; i < t.Length; i++) {
            s += (t[i] - o[i]) * (t[i] - o[i]);
        }
//        return System.Math.Sqrt (s);
        return s * 0.5;
    }

	public static void printArray(string header, double[] arr) {
		string o = "";
		foreach (double d in arr) {
			o += d.ToString() + " ";
		}
		Debug.Log(header + o);
	}

    public static double[] getRandomWeights(int size) {
        System.Random rand = new System.Random ();
        double[] w = new double[size];
        for (int i = 0; i < size; i++) {
            w[i] = rand.NextDouble();
        }
        return w;
    }

    public static void writeWeights(string name, double[] weights) {
		string o = Application.dataPath + "/Datas/" + name + "Weights.ttd";
        if (File.Exists (@o)) {
            using (StreamWriter writer = new StreamWriter(new FileStream(@o, FileMode.Truncate, FileAccess.Write, FileShare.Read))) {
                foreach(double d in weights) {
                    writer.WriteLine(d);
                }
            }
        } else {
            using (StreamWriter writer = new StreamWriter(new FileStream(@o, FileMode.CreateNew, FileAccess.Write, FileShare.Read))) {
                foreach(double d in weights) {
                    writer.WriteLine(d);
                }
            }
        }
    }
}
