using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timmoc : MonoBehaviour {

    public int speed;
    public int maxHealth;

    private int currentHealth;


	// Use this for initialization
	void Awake () {
        currentHealth = maxHealth;
	}

    void Update () {

    }

    public void takeDamage(int damage) {
        currentHealth -= damage;
    }
}
