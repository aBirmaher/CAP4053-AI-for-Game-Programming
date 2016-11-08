using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

    private Spawner spawner;

    void Awake () {
        spawner = gameObject.GetComponent<Spawner>();
    }

	// Use this for initialization
	void Start () {
        spawner.enabled = true; // Test purpose
	}
	
	// Update is called once per frame
//	void Update () {
//
//	}
}
