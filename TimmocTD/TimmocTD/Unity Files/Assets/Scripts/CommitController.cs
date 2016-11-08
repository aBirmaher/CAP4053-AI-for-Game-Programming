using UnityEngine;
using System.Collections;

//Move class
public class CommitController : MonoBehaviour {

	//Set up variables
	public float movespeed;
	public float rotatespeed;
	int vc = 20;
	bool hasMoved = false;
	Vector3 origPos;
	public double[] movement;
	public int randomChange;
	// Use this for initialization
	void Start () {
		//[0] = L/R; [1] = U/D
		movement =		 new double[2] {.5,.5};
		LineRenderer line = gameObject.AddComponent<LineRenderer> ();
		line.useWorldSpace = true;
		line.material = new Material (Shader.Find ("Particles/Additive"));
		line.SetColors (Color.cyan, Color.red);
		line.SetVertexCount (vc);
		line.SetWidth (0.05f, 0.05f);
		origPos = transform.position;
	}

	// Update function, update is called once per frame
	void Update () {

		//If left arrow is pressed
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
						movement [0] = 0;
						hasMoved = true;
						rotate (rotatespeed);

				}

		//If right arrow is pressed
		else if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
						movement [0] = 1;
						hasMoved = true;
						rotate (-rotatespeed);

				} else {
			movement[0] = .5;
				}

		//If up arrow is pressed
		if( Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) ) {
			movement[1] = 1;
			hasMoved = true;
			//Move forward
			move(movespeed);

		}

		//If down arrow is pressed
		else  if( Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) ) {
			movement[1] = 0;
			hasMoved = true;
			//Move backwards
			move(-movespeed);

		}	else {
			movement[1] = .5;
		}

	}
	
	public bool getHasMoved(){
		return hasMoved;
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Gizmos.DrawRay (transform.position, transform.up * 5);
	}

	void FixedUpdate() {
		Debug.DrawRay (transform.position, transform.up * 5, Color.red);
		LineRenderer line = GetComponent<LineRenderer> ();
		for (int i = 0; i < vc; i++) {
			Vector3 pos = transform.position + transform.up * i;
			line.SetPosition (i, pos);
		}

	}

	void OnTriggerEnter2D( Collider2D other) {
		Debug.Log ("collision");
		Debug.Log (other.gameObject.tag);
		if (other.gameObject.tag == "timmoc") {
			Debug.Log("space goast toast to toast");
			Vector3 newPos = origPos;
			newPos.x -= Random.Range(0,randomChange);
			newPos.y -= Random.Range(0,randomChange);
			transform.position = newPos;
			rotate ((double)0);
		}
	}

	public void rotate(float t) {
		transform.rotation = Quaternion.Euler(0, 0, getHeading() + t);
	}

	public void move(float movespeed) {
		transform.position += transform.up * movespeed;
	}

	public void rotate(double t) {
		//Debug.Log (t);
		transform.rotation = Quaternion.Euler(0, 0, (float) t);
	}
	
	public void move(double movespeed) {
		move ((float)movespeed);
	}

	public float getHeading() {
		return transform.eulerAngles.z;
	}

}