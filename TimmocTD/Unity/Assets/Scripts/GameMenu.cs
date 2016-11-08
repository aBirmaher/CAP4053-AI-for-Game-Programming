using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour {

	public GameObject loadingImage;

	public void LoadScene(string level) {
		loadingImage.SetActive (true);
		Application.LoadLevel (level);
	}
}
