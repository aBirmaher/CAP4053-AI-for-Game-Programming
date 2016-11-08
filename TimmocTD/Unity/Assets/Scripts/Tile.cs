using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	public bool walkable;
	public bool buildable;
	private bool built;
	private GameObject tower;

	void Start() {
		built = false;
	}

	public bool buildTower(Transform t) {
		if (!built) {
<<<<<<< HEAD
			tower = Instantiate (t.gameObject, new Vector3 (transform.position.x, transform.position.y, -2f), Quaternion.identity) as GameObject;
=======
			tower = Instantiate (t.gameObject, new Vector3 (transform.position.x, transform.position.y, transform.position.z - 1), Quaternion.identity) as GameObject;
>>>>>>> cd3c54cdc1382c9281f8215a0e5df8fe489c3d23
			Debug.Log(tower);
			built = true;
			return true;
		}
		return false;
	}

	public void destoryTower() {
		built = false;
<<<<<<< HEAD
        tower.GetComponent<Tower>().destroyAttackRange();
=======
>>>>>>> cd3c54cdc1382c9281f8215a0e5df8fe489c3d23
		Destroy (tower);
	}

	public bool hasTower() {
		return tower != null;
	}

	public GameObject getTower() {
		return tower;
	}
	/*
	public Tile (Transform tile, bool walkable, float x, float y)
	{	
		this.tile = tile;
		this.xTile = (int) x;
		this.yTile = (int) y;
		this.xPixel = x*128/100;
		this.yPixel = y*128/100;
	}
	
	public void display() {
		tileRef = Instantiate(tile, new Vector3(xPixel, yPixel, 0), Quaternion.identity);
	}
	
	void OnMouseDown(){
		if (!builtTower) {
			float x = this.gameObject.transform.position.x;
			float y = this.gameObject.transform.position.y;
			//Debug.Log ("(" + x + ", " + y + ")");
			towerRef = Instantiate (tower, new Vector3 (x, y, 0), Quaternion.identity);
			builtTower = true;
		}
	} 

	public Texture btnTexture;
	void OnGUI() {
		if (!buildMode)
			return;
		if (!btnTexture) {
			Debug.LogError("Please assign a texture on the inspector");
			return;
		}
		//if (GUI.Button(new Rect(.1f,.1f,5,5), btnTexture))
			//Debug.Log("Clicked the button with an image");
		if (GUI.Button(new Rect(5,5,50,50), "Temp1"))
			Debug.Log("Clicked the button with text");
		
	}
	public Vector3 getPos(){
		return this.transform.position;
	}
	public Vector2 getCenter(){
		return new Vector2 (xPixel, yPixel);
	}
	*/
}

