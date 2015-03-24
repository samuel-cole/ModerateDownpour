using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public GameObject pauseScreen;

	public void OnStart() {
		Time.timeScale = 1.0f;
		Application.LoadLevel ("Game");
	}

	public void OnCredits() {
		Time.timeScale = 1.0f;
		Application.LoadLevel ("Credits");
	}

	public void OnMenu() {
		Time.timeScale = 1.0f;
		Application.LoadLevel ("Menu");
	}

	public void OnQuit() {
		Application.Quit ();
	}

	public void OnPause() {
		Time.timeScale = 0.0f;
		Instantiate (pauseScreen);
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		player.transform.FindChild ("MusicSound").GetComponent<AudioSource>().Pause();
		player.transform.FindChild ("PauseMusicSound").GetComponent<AudioSource> ().Play ();

		Camera.main.transform.FindChild ("ButtonPressSound").GetComponent<AudioSource> ().Play ();
	}

	public void OnResume() {
		Time.timeScale = 1.0f;
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		player.transform.FindChild ("MusicSound").GetComponent<AudioSource>().Play();
		player.transform.FindChild ("PauseMusicSound").GetComponent<AudioSource> ().Pause ();

		Camera.main.transform.FindChild ("ButtonPressSound").GetComponent<AudioSource> ().Play ();

		Destroy (gameObject);
	}
}
