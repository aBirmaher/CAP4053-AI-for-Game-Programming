using System.Collections;
using System.IO;
using System.Globalization;
public class Record {
	Recorder rec;
	void Start () {
		rec = new Recorder ();
	}
}

public class Recorder {

	private string outputFile = "datas.txt";
	public Recorder() {
	}
	int ctr = 0;
	public void read(ArrayList list) {
		//Debug.Log (ctr++);
		int inputSize = 6, targetSize = 2;
		using (StreamReader reader = new StreamReader(new FileStream(@outputFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))) {
			while (!reader.EndOfStream) {
				string inStr = reader.ReadLine();
				string tarStr = reader.ReadLine();
				if (inStr != null && inStr != "") {
					string[] split = inStr.Split(',');
					double[] inputs = new double[inputSize];
					double[] targets = new double[targetSize];
					for (int i = 0; i < inputSize; i++) {
						inputs[i] = double.Parse(split[i],CultureInfo.InvariantCulture);
					}
					
					targets[0] = double.Parse(tarStr.Split(',')[0],CultureInfo.InvariantCulture);
					targets[1] = double.Parse(tarStr.Split(',')[1],CultureInfo.InvariantCulture);
					list.Add(new TrainingSet(inputs, targets));
				}
			}
		}
	}
}
