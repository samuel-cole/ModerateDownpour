using UnityEngine;
using System.Collections;

public class BuildingScript : MonoBehaviour {

	private GameObject player;
	public float deleteDistance;

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
		}
	}
}
