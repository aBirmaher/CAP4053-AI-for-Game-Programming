using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameBoard : MonoBehaviour {
	public static float spriteRatio = 1.28f;
	public static int boardWidth = 10;
	public static int boardHeight = 10;

	public Camera cam;
	public Transform laserTower, fireTower, bombTower;
	public Transform highGround, lowGround;
	public GameObject scoreO, timbuxO, waveO, msgO;

	private int score, timbux, wave, towerPrice;
	private Text scoreT, timbuxT, waveT, msgT;
	private Transform selectedBuildTower;
<<<<<<< HEAD
    private GameObject preSelectedTower, selectedTower, towerOption, towerMenu;
    private bool selected = false, towerOptionToggle;
    public GameObject[,] tiles = new GameObject[boardWidth, boardHeight];
	public Vector2 spawnPoint;  // Set this in Unity Editor
=======
	private GameObject selectedTower;
	private bool selected = false;
	public GameObject[,] tiles = new GameObject[boardWidth, boardHeight];
	private Tile[,] board = new Tile[boardWidth,boardHeight];
	public Vector2 spawnPoint = new Vector2(1,0);
>>>>>>> cd3c54cdc1382c9281f8215a0e5df8fe489c3d23
	public int[,] path;

	void Start () {
		scoreT = scoreO.GetComponent<Text> ();
		timbuxT = timbuxO.GetComponent<Text> ();
		waveT = waveO.GetComponent<Text> ();
		msgT = msgO.GetComponent<Text> ();
<<<<<<< HEAD
        towerMenu = GameObject.Find ("Tower Menu");
        towerOption = GameObject.Find ("Tower Option");
=======
>>>>>>> cd3c54cdc1382c9281f8215a0e5df8fe489c3d23
		score = 0;
		timbux = 1000000;
		wave = 1;
		path = new int[,] {
			{ 0,2,0,0,0,0,0,0,0,0 },
			{ 0,1,1,1,1,1,1,1,1,0 },
			{ 0,0,0,0,0,0,0,0,1,0 },
			{ 0,1,1,1,1,1,1,1,1,0 },
			{ 0,1,0,0,0,0,0,0,0,0 },
			{ 0,1,1,1,1,1,1,1,1,0 },
			{ 0,0,0,0,0,0,0,0,1,0 },
			{ 0,1,1,1,1,1,1,1,1,0 },
			{ 0,1,0,0,0,0,0,0,0,0 },
			{ 0,1,0,0,0,0,0,0,0,0 },
		};

		for (int i = 0; i < 10; i++) {
			for (int j = 0; j < 10; j++) {
<<<<<<< HEAD
				if(path[i,j] == 0)
					tiles[i,j] = Instantiate(highGround.gameObject, new Vector3(j * spriteRatio, i * spriteRatio, 0f), Quaternion.identity) as GameObject;
				else
					tiles[i,j] = Instantiate(lowGround.gameObject, new Vector3(j * spriteRatio, i * spriteRatio, 0f), Quaternion.identity) as GameObject;
=======
				if(path[j,i] == 0)
					tiles[i,j] = Instantiate(highGround.gameObject, new Vector3(i * spriteRatio, j * spriteRatio, 0f), Quaternion.identity) as GameObject;
				else
					tiles[i,j] = Instantiate(lowGround.gameObject, new Vector3(i * spriteRatio, j * spriteRatio, 0f), Quaternion.identity) as GameObject;
>>>>>>> cd3c54cdc1382c9281f8215a0e5df8fe489c3d23
			}
		}
	}

	void Update() {
<<<<<<< HEAD
		if (Input.GetMouseButtonDown (0)) {                                     // If left click
			RaycastHit2D hit = Physics2D.Raycast (new Vector2 (cam.ScreenToWorldPoint (Input.mousePosition).x, cam.ScreenToWorldPoint (Input.mousePosition).y), Vector2.zero, 0f);
			try {
				if (hit.transform.gameObject.tag == "buildable") {              // Check if the hit is a high ground
					Tile t = hit.transform.gameObject.GetComponent<Tile>();     // Get hit tile
                    if (selected && t.buildTower(selectedBuildTower)) {         // Check if a pre-build tower is selcted to build, and build tower IF current tile has no tower
						selected = false;                                       // Make select to false if build complete
						timbux -= towerPrice;                                   // Deduct timbux
					}
				} else if (hit.transform.gameObject.tag == "tower") {           // Check if the hit is a tower
                    selected = false;                                           // Make select to false in case there is a pre-build tower is selected and causes bug 
					selectedTower = hit.transform.gameObject;                   // Get the selected tower
                    if (System.Object.Equals(selectedTower, preSelectedTower)) {
                        toggleTowerOption();
                    } else {
                        towerOptionToggle = false;
                        toggleTowerOption();
                        if  (preSelectedTower != null)
                            preSelectedTower.GetComponent<Tower>().destroyAttackRange();
                        preSelectedTower = selectedTower;
                    }
=======
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit2D hit = Physics2D.Raycast (new Vector2 (cam.ScreenToWorldPoint (Input.mousePosition).x, cam.ScreenToWorldPoint (Input.mousePosition).y), Vector2.zero, 0f);
			try {
				if (hit.transform.gameObject.tag == "buildable") {
					Tile t = hit.transform.gameObject.GetComponent<Tile>();
					if (selected && t.buildTower(selectedBuildTower)) {
						selected = false;
						timbux -= towerPrice;
					}
				} else if (hit.transform.gameObject.tag == "tower") {
					selectedTower = hit.transform.gameObject;
>>>>>>> cd3c54cdc1382c9281f8215a0e5df8fe489c3d23
				}
#pragma warning disable 168
			} catch (NullReferenceException e) {
#pragma warning restore 168
				//Do nothing
			}
<<<<<<< HEAD
		}
		if (Input.GetMouseButtonDown (1)) {                                     // If right click
            selected = false;                                                   // Make select to false to cancel building process
			Debug.Log(selected);
		}
		scoreT.text = score.ToString();                                         // Set UI for score
		timbuxT.text = timbux.ToString();                                       // Set UI for timbux
		waveT.text = wave.ToString();                                           // Set UI for wave
	}


    /// <summary>
    /// Raises the GU event.
    /// If there is a pre-build tower is selected, make it follow the mouse
    /// </summary>
	void OnGUI() {
		if (selected) {
			float size = Screen.height * 68f / 689f;                            // Ratio between screen size and sprite size
=======
		}
		if (Input.GetMouseButtonDown (1)) {
			selected = false;
			Debug.Log(selected);
		}
		scoreT.text = score.ToString();
		timbuxT.text = timbux.ToString();
		waveT.text = wave.ToString();
	}

	void OnGUI() {
		if (selected) {
			float size = Screen.height * 68f / 689f;
>>>>>>> cd3c54cdc1382c9281f8215a0e5df8fe489c3d23
			Vector3 mp = Input.mousePosition;
			GUI.DrawTexture(new Rect(mp.x, Screen.height - mp.y, size, size), selectedBuildTower.GetComponent<Tower>().texture, ScaleMode.ScaleToFit, true, 0f);
		}
	}

<<<<<<< HEAD
    /// <summary>
    /// UI button method.
    /// Selects the tower.
    /// </summary>
    /// <param name="tower">Selected pre-build tower.</param>
	public void selectTower(Transform tower) {
        selectedBuildTower = tower;                                             // Get selected pre-build tower
		towerPrice = tower.GetComponent<Tower>().price;                         // Get selected pre-build tower price
		Debug.Log (towerPrice);
		if (timbux < towerPrice) {                                              // Check if player has enough timbux
			msgT.color = new Color(156f/255f, 0f, 0f);
            msgT.text = "Insufficient Funds";                                   // Indicates "Insufficient Funds"
		} else {
			msgT.color = new Color(0f, 202f/255f, 1f);
			msgT.text = tower.GetComponent<Tower>().description;
            selected = true;                                                    // Make selected to true if has enough timbux
=======
	public void selectTower(Transform tower) {
		selectedBuildTower = tower;
		towerPrice = tower.GetComponent<Tower>().price;
		Debug.Log (towerPrice);
		if (timbux < towerPrice) {
			msgT.color = new Color(156f/255f, 0f, 0f);
			msgT.text = "Insufficient Funds";
		} else {
			msgT.color = new Color(0f, 202f/255f, 1f);
			msgT.text = tower.GetComponent<Tower>().description;
			selected = true;
>>>>>>> cd3c54cdc1382c9281f8215a0e5df8fe489c3d23
		}
	}

	
	public void upgradeTower() {
<<<<<<< HEAD
        Tower tower = selectedTower.GetComponent<Tower> ();
        // Do something with the tower
	}
	
    /// <summary>
    /// UI button method, only available when a tower is selected.
    /// Sells the tower and gets half of its price back.
    /// </summary>
	public void sellTower() {
		Tower tower = selectedTower.GetComponent<Tower> ();                     // Gets the selected tower
		int x = (int) Mathf.Ceil((tower.transform.position.y / spriteRatio));   // Get index
		int y = (int) Mathf.Ceil((tower.transform.position.x / spriteRatio));   // Get index
        resetOptionUI();                                                        // Hide tower option menu
		tiles [x, y].GetComponent<Tile> ().destoryTower ();                     // Destroy tower
		timbux += tower.price / 2;                                              // Reinburst
	}

    private void toggleTowerOption() {
        towerMenu.SetActive (towerOptionToggle);
        towerOptionToggle = !towerOptionToggle;
        if (towerOptionToggle) {
            towerOption.GetComponent<RectTransform>().localPosition = new Vector3(-310.74f, 33, 0);
            selectedTower.GetComponent<Tower>().showAttackRange();
        } else {
            resetOptionUI();
            selectedTower.GetComponent<Tower>().destroyAttackRange();
        }
    }

    private void resetOptionUI() {
        towerMenu.SetActive (true);
        towerOption.GetComponent<RectTransform>().localPosition = new Vector3(-636f, 33, 0);
    }

    /// <summary>
    /// Debugs the tiles.
    /// </summary>
=======
		
	}
	
	public void sellTower() {
		Tower tower = selectedTower.GetComponent<Tower> ();
		int x = (int) Mathf.Ceil((tower.transform.position.x / spriteRatio));
		int y = (int) Mathf.Ceil((tower.transform.position.y / spriteRatio));
		tower.resetOptionUI ();
		tiles [x, y].GetComponent<Tile> ().destoryTower ();
		timbux += tower.price / 2;
	}

>>>>>>> cd3c54cdc1382c9281f8215a0e5df8fe489c3d23
	void debugTiles() {
		for (int i = 0; i < boardWidth; i++) {
			for (int j = 0; j < boardHeight; j++) {
				Tile t = tiles[i,j].GetComponent<Tile>();
				if (t.hasTower())
					Debug.Log(i + " " + j);
			}
		}
	}

	/*************** Unused code *************/
	void placeTower() {
		Instantiate(laserTower, new Vector3(((float)-128/100 - 1), ((float)0), 0), Quaternion.identity);
		Instantiate(fireTower, new Vector3(((float)-128/100 - 1), ((float)128/100), 0), Quaternion.identity);
		Instantiate(bombTower, new Vector3(((float)-128/100 - 1), ((float)256/100), 0), Quaternion.identity);
	}

}





















