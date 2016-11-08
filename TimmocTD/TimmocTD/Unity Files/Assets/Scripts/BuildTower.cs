using UnityEngine;
using System.Collections;

public class BuildTower : MonoBehaviour {

	GameObject scriptMan;
	GameBoard genGround; 
	BuildGUI buildGUI;
	//add tower build gui in here
	void Start () {
		scriptMan = GameObject.Find ("ScriptMan");
		//genGround = scriptMan.GetComponent<GameBoard> ();
	}

	ArrayList towerList = new ArrayList();
	
	void OnMouseDown(){
		//Debug.Log ("111111");
	}   
}
