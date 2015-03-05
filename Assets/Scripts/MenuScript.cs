using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public GameObject Manager = null;

	private bool alreadyClicked = false;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	public void OnStart() {
		Application.LoadLevel ("Game");
	}

	public void OnStart2() {
		if (Manager != null && !alreadyClicked) {
			Instantiate (Manager);
			alreadyClicked = true;
		}
	}
	
	public void OnQuit() {
		Application.Quit ();
	}
}
