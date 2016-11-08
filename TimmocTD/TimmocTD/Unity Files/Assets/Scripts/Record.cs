using UnityEngine;
using System.Collections;
using System.IO;
using System.Globalization;
public class Record : MonoBehaviour {
	
	GameObject tower;
	Recorder rec;
	PieSliceSensor pie;
	double time;
	TowerController cont;
	// Use this for initialization
	void Start () {
		tower = GameObject.FindGameObjectWithTag ("tower");
<<<<<<< HEAD
        Debug.Log(tower);
=======
>>>>>>> cd3c54cdc1382c9281f8215a0e5df8fe489c3d23
		pie = tower.GetComponent<PieSliceSensor> ();
		cont = tower.GetComponent<TowerController> ();
		rec = new Recorder ();
		time = Time.time;
<<<<<<< HEAD
        if (File.Exists(@rec.outputFile))
            File.Delete(@rec.outputFile);
    }
    
    // Update is called once per frame
	void FixedUpdate () {
		//outputs data five times per second
		if (/*(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && cont.getHasMoved() && */Time.time - time > .2f) {
=======

//		wall = player.GetComponent<WallSensor> ();
//		radar = player.GetComponent<AdjacentSensor> ();

	}

	// Update is called once per frame
	void FixedUpdate () {
		//outputs data five times per second
		if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) /*&& cont.getHasMoved()*/ && Time.time - time > .2f) {
>>>>>>> cd3c54cdc1382c9281f8215a0e5df8fe489c3d23
			rec.write (cont, pie);
			time = Time.time;
		}
	}


}

public class Recorder {

<<<<<<< HEAD
	public string outputFile = Application.dataPath + "/Datas/data.txt";

	public Recorder() {

    }
    
    public void write(TowerController cont, PieSliceSensor pie) {

		using (StreamWriter writer = new StreamWriter(new FileStream(@outputFile, FileMode.Append, FileAccess.Write, FileShare.Read))) {    // Rewrite exist file
			string s = pie.toRecordString(pie.getNormQuadrant());
			s += cont.getHeading() / 360.0;
=======
	private string outputFile = Application.dataPath + "/Datas/data.txt";

	public Recorder() {

	}

	public void write(TowerController cont, PieSliceSensor pie) {
		using (StreamWriter writer = new StreamWriter(new FileStream(@outputFile, FileMode.Append, FileAccess.Write, FileShare.Read))) {
			string s = pie.toRecordString(pie.getNormQuadrant());
>>>>>>> cd3c54cdc1382c9281f8215a0e5df8fe489c3d23
			writer.WriteLine(s);
			writer.WriteLine(cont.movement[0] + "," + cont.movement[1]);
		}
	}

    public ArrayList read(int inputSize, int targetSize) {
        ArrayList list = new ArrayList ();
        using (StreamReader reader = new StreamReader(new FileStream(@outputFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))) {
            while (!reader.EndOfStream) {
                string inStr = reader.ReadLine();
                string tarStr = reader.ReadLine();
                if (inStr != null && inStr != "") {
                    string[] splitInput = inStr.Split(',');
                    string[] splitTarget = tarStr.Split(',');
                    double[] inputs = new double[inputSize];
                    double[] targets = new double[targetSize];
                    for (int i = 0; i < inputSize; i++) {
                        inputs[i] = System.Convert.ToDouble(splitInput[i]);
                    }
                    for (int i = 0; i < targetSize; i++) {
                        targets[i] = System.Convert.ToDouble(splitTarget[i]);
                    }
                    list.Add(new NeuralNetworkTrainingSet(inputs, targets));
                }
            }
        }
        return list;
    }
}
