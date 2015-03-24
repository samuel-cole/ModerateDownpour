using UnityEngine;
using System.Collections;

public class FrontObstical : MonoBehaviour {
	
	private GameObject player = null;
	private bool splashed = false;
	public float speed = 3;
	public float deleteDistance = 50;

	public GameObject obstical1;
	public GameObject obstical2;

	private Vector3 rotationDirection;
	private GameObject myObj;
	
	// Use this for initialization
	void Start () {
		//Inclusive for first value, not-inclusive for second.
		int value = Random.Range (0, 2);

		if (value == 0) {
			myObj = Instantiate(obstical1);
		} else {
			myObj = Instantiate(obstical2);
		}
		myObj.transform.parent = transform;
		myObj.transform.localPosition = new Vector3(0, 0, 0);

		rotationDirection = Random.onUnitSphere;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x - speed, transform.position.y, transform.position.z);
		transform.Rotate (rotationDirection);
		
		if (player == null)
			player = GameObject.FindGameObjectWithTag("Player");

		if (!splashed && Mathf.Abs (player.transform.position.x - gameObject.transform.position.x) < 1.5f && player.GetComponent<PlayerScript>().umbrellaUp == false) {
			splashed = true;
			player.GetComponent<PlayerScript>().CheckCollision(false, false);
			player.transform.FindChild ("SplashSound").GetComponent<AudioSource>().Play ();
			DestroyObject (gameObject);
		}
		
		if (!splashed && Mathf.Abs (player.transform.position.x - gameObject.transform.position.x) < 0.5f) {
			splashed = true;
			player.GetComponent<PlayerScript>().CheckCollision(false, false);
			player.transform.FindChild ("SplashSound").GetComponent<AudioSource>().Play ();
			DestroyObject (gameObject);
		}
		
		if (transform.position.x < player.transform.position.x - deleteDistance)
			DestroyObject (gameObject);
	}
}
