using System.Collections;

public class NeuralNetworkHelpers {

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
		return System.Math.Sqrt (s);
	}

	public static void printArray(string header, double[] arr) {
		string o = "";
		foreach (double d in arr) {
			o += d.ToString() + " ";
		}
	}
}
