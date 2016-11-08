using UnityEngine;
using System.Collections;

public class TowerShooter : MonoBehaviour {

	//For adding multiple timmocs we need to make this an array
	private GameObject enemyLoc;

	public GameObject projectile;
	public float lastShot;	// Set it in Unity Editor


	// Use this for initialization
	void Start () {
	
		// Also change to FindGameObjectsWithTag
		enemyLoc = GameObject.FindGameObjectWithTag("timmoc");
		Debug.Log("Tower spawned");

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) {
			ShootBomb();
		}
	
	}

	public void fire() {
		ShootBomb ();
	}

	private void ShootBomb(){
		if (Time.time - lastShot < 1)
			return;
		lastShot = Time.time;
		Debug.Log("shoot");

		//Vector3 shootDir = enemyLoc.transform.localPosition - this.transform.position;
		Debug.Log (enemyLoc.transform.position);
		GameObject temp = Instantiate (projectile, this.transform.position, Quaternion.identity) as GameObject;
		temp.GetComponent<Bullet> ().setTarget (enemyLoc);
		//Destroy (temp, timeToDestroyBullet);
		//temp.rigidbody2D.velocity = shootDir*projectileSpeed;
	}





}
