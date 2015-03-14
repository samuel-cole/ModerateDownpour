using UnityEngine;
using System.Collections;

public class BuildingScript : MonoBehaviour {

	private GameObject player;
	public float deleteDistance;

	private bool passed = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (player == null)
			player = GameObject.FindGameObjectWithTag ("Player");
		else {
			if (gameObject.transform.position.x < player.transform.position.x - deleteDistance) {
				DestroyObject (this.gameObject);
			}
			else if (!passed && Mathf.Abs (player.transform.position.x - gameObject.transform.position.x) < 0.5f) {
				passed = true;
				player.GetComponent<PlayerScript>().housesPassed++;
			}
		}
	}
}
