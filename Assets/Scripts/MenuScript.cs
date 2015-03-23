using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public GameObject pauseScreen;

	public void OnStart() {
		Application.LoadLevel ("Game");
	}

	public void OnCredits() {
		Application.LoadLevel ("Credits");
	}

	public void OnMenu() {
		Application.LoadLevel ("Menu");
	}

	public void OnQuit() {
		Application.Quit ();
	}

	public void OnPause() {
		Time.timeScale = 0.0f;
		Instantiate (pauseScreen);
	}

	public void OnResume() {
		Time.timeScale = 1.0f;
		Destroy (gameObject);
	}
}
