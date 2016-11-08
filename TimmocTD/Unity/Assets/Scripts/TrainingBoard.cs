using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TrainingBoard : MonoBehaviour {
	public static float spriteRatio = 1.28f;
	public static int boardWidth = 5;
	public static int boardHeight = 10;

	public Camera cam;
	public Transform highGround, lowGround;
	public Transform defaultTrainingTower;
	public GameObject towerSelectPanel, message, sTrain, eTrain, sRecord, eRecord;
<<<<<<< HEAD
    public Vector2 spawnPoint;  // Set this in Unity Editor

    private bool built, recorded, training, recording;
    private Tile t;
    private GameObject selectedTrainingTower, builtTower;
    private GameObject levelManager;
    private Trainer trainer;
    private Spawner spawner;
	public GameObject[,] tiles = new GameObject[boardWidth, boardHeight];
=======

	private bool built, recorded;
	private int x, y;							// x and y for tile index
	private GameObject selectedTrainingTower;
	private GameObject[,] tiles = new GameObject[boardWidth, boardHeight];
>>>>>>> cd3c54cdc1382c9281f8215a0e5df8fe489c3d23

	// Use this for initialization
	void Start () {
		int[,] path;
		path = new int[,] {
			{ 0,0,0,0,0,0,0,0,0,0 },
			{ 0,1,1,1,1,1,1,1,1,0 },
			{ 0,1,0,0,0,0,0,0,1,0 },
			{ 0,1,1,1,1,1,1,1,1,0 },
			{ 0,0,0,0,0,0,0,0,0,0 },
		};
		for (int i = 0; i < 5; i++) {
			for (int j = 0; j < 10; j++) {
				if(path[i,j] == 0)
					tiles[i,j] = Instantiate(highGround.gameObject, new Vector3(j * spriteRatio, i * spriteRatio, 0f), Quaternion.identity) as GameObject;
				else
					tiles[i,j] = Instantiate(lowGround.gameObject, new Vector3(j * spriteRatio, i * spriteRatio, 0f), Quaternion.identity) as GameObject;
			}
		}
		selectedTrainingTower = defaultTrainingTower.gameObject;
<<<<<<< HEAD
        levelManager = GameObject.Find("LevelManager");
        trainer = levelManager.GetComponent<Trainer>();
        spawner = levelManager.GetComponent<Spawner>();
=======
>>>>>>> cd3c54cdc1382c9281f8215a0e5df8fe489c3d23
		eTrain.SetActive (false);
		eRecord.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit2D hit = Physics2D.Raycast (new Vector2 (cam.ScreenToWorldPoint (Input.mousePosition).x, cam.ScreenToWorldPoint (Input.mousePosition).y), Vector2.zero, 0f);
			try {
				if (hit.transform.gameObject.tag == "buildable") {
<<<<<<< HEAD
					t = hit.transform.gameObject.GetComponent<Tile>();
					if (!built && t.buildTower(selectedTrainingTower.transform)) {
                        builtTower = t.getTower();
                        builtTower.AddComponent<TowerController> (); // attach controller
                        builtTower.GetComponent<Tower>().showAttackRange();
=======
					Tile t = hit.transform.gameObject.GetComponent<Tile>();
					if (!built && t.buildTower(selectedTrainingTower.transform)) {
						x = (int) Mathf.Ceil(t.transform.position.x / spriteRatio);
						y = (int) Mathf.Ceil(t.transform.position.y / spriteRatio);
						Debug.Log(x + " " + y);
>>>>>>> cd3c54cdc1382c9281f8215a0e5df8fe489c3d23
						built = true;
						towerSelectPanel.GetComponent<RectTransform> ().localPosition = new Vector3 (86f, -169f, 0f);
					}
				} else if (hit.transform.gameObject.tag == "tower") {
//					selectedTower = hit.transform.gameObject;
				}
#pragma warning disable 168
			} catch (NullReferenceException e) {
#pragma warning restore 168
				//Do nothing
			}
		}
	}

	void OnGUI() {
		if (!built) {
			float size = Screen.height * 68f / 689f;
			Vector3 mp = Input.mousePosition;
			GUI.DrawTexture(new Rect(mp.x, Screen.height - mp.y, size, size), selectedTrainingTower.GetComponent<Tower>().texture, ScaleMode.ScaleToFit, true, 0f);
		}
	}

	public void startRecording() {
		towerSelectPanel.GetComponent<RectTransform> ().localPosition = new Vector3 (86f, -169f, 0f);
<<<<<<< HEAD
		if (!built || training) return;
        recording = true;
		sRecord.SetActive (false);
		eRecord.SetActive (true);
		message.GetComponent<Text> ().text = "";
        levelManager.AddComponent<Record>();    // attach record
        spawner.enabled = true;
	}

	public void stopRecording() {
        //spawner.enabled = false;
        recording = false;
        Destroy(levelManager.GetComponent<Record>());	// detach record
=======
		if (!built) return;
		sRecord.SetActive (false);
		eRecord.SetActive (true);
		message.GetComponent<Text> ().text = "";
		tiles [y, x].GetComponent<Tile> ().getTower ().AddComponent<TowerController> ();	// attach controller
		tiles [y, x].GetComponent<Tile> ().getTower ().AddComponent<Record> ();				// attach recorder
	}

	public void stopRecording() {
		Destroy (tiles [y, x].GetComponent<Tile> ().getTower ().GetComponent<Record> ());	// detach record
		Destroy (tiles [y, x].GetComponent<Tile> ().getTower ().GetComponent<TowerController> ());	// detach controller
>>>>>>> cd3c54cdc1382c9281f8215a0e5df8fe489c3d23
		sRecord.SetActive (true);
		eRecord.SetActive (false);
		recorded = true;
		message.GetComponent<Text> ().text = "Recording is done!";
	}

	public void startTraining() {
		towerSelectPanel.GetComponent<RectTransform> ().localPosition = new Vector3 (86f, -169f, 0f);
		if (!built) return;
		if (recorded) {
<<<<<<< HEAD
            training = true;
			sTrain.SetActive(false);
			eTrain.SetActive(true);
			message.GetComponent<Text>().text = "";
			//train
            trainer.enabled = true;
=======
			sTrain.SetActive(false);
			eTrain.SetActive(true);
			message.GetComponent<Text>().text = "Training in progress...";
			//train
>>>>>>> cd3c54cdc1382c9281f8215a0e5df8fe489c3d23
		} else {
			message.GetComponent<Text>().text = "No record data!";
		}
	}

	public void stopTraining() {
<<<<<<< HEAD
        spawner.enabled = false;
		// Write weight
        message.GetComponent<Text>().text = "Training Complete!";
        trainer.writeWeights(builtTower.GetComponent<Tower>().towerName);
        trainer.enabled = false;
        training = false;
        sTrain.SetActive(true);
        eTrain.SetActive(false);
	}

	public void changeTower() {
        if (training || recording)
            return;
		message.GetComponent<Text>().text = "";
        if (built)
		    t.destoryTower ();
=======
		sTrain.SetActive(true);
		eTrain.SetActive(false);
		// Write weight
		// Show result
	}

	public void changeTower() {
		stopTraining ();
		message.GetComponent<Text>().text = "";
		tiles [y, x].GetComponent<Tile> ().destoryTower ();
>>>>>>> cd3c54cdc1382c9281f8215a0e5df8fe489c3d23
		towerSelectPanel.GetComponent<RectTransform> ().localPosition = new Vector3 (86f, 6f, 0f);
		built = false;
		recorded = false;
	}

	public void selectTower(Transform tower) {
		selectedTrainingTower = tower.gameObject;
		towerSelectPanel.GetComponent<RectTransform> ().localPosition = new Vector3 (86f, -169f, 0f);
	}
}
