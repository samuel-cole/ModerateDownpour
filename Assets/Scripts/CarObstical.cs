using UnityEngine;
using System.Collections;

public class CarObstical : MonoBehaviour {

	private GameObject player = null;
	private bool splashed = false;
	public float speed = 3;
	public float deleteDistance = 50;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x + speed, transform.position.y, transform.position.z);

		if (player == null)
			player = GameObject.FindGameObjectWithTag("Player");

		if (!splashed && Mathf.Abs (player.transform.position.x - gameObject.transform.position.x) < 0.5f) {
			splashed = true;
			player.GetComponent<PlayerScript>().CheckCollision(false, false);
		}

		if (transform.position.x > player.transform.position.x + deleteDistance)
			DestroyObject (gameObject);
	}
}
