using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public bool umbrellaUp = true;
	public float speed = 1.0f;
	public float wetnessThreshold = 100.0f;
	public uint housesPassed = 0;
	public Material testMaterial;
	public Material testMaterial2;
	public GameObject gameOverHUD;

	private float wetness = 0.0f;
	private bool dead = false;

	public bool IsAlive {
		get { return !dead;}
		set { dead = !value; }
	}


	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (!dead) {
			Debug.Log (housesPassed);

			gameObject.transform.position = new Vector3 (gameObject.transform.position.x + speed * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);

			if (Input.GetKeyDown (KeyCode.Space)) {
				umbrellaUp = !umbrellaUp;
				if (umbrellaUp)
					(gameObject.GetComponent<MeshRenderer> () as MeshRenderer).material = testMaterial;
				else
					(gameObject.GetComponent<MeshRenderer> () as MeshRenderer).material = testMaterial2;
			}


			if (!umbrellaUp)
			{
				wetness += Time.deltaTime;
				if (wetness >= wetnessThreshold)
				{
					Die();
				}
			}

			Debug.Log (wetness);

			Camera.main.transform.position = new Vector3 (transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
		}
	}

	//This function is called when a collision is occuring with the player. 
	//Set a_umbrellaShouldBeUp to true for collisions that would impact the player if his umbrella was down, and vice versa.
	//Set a_fatal to true for fatal collisions (eg: lightning) and false for non-fatal ones (eg: spray from passing car).
	public void CheckCollision (bool a_umbrellaShouldBeUp, bool a_fatal)
	{
		if (umbrellaUp != a_umbrellaShouldBeUp) {
			if (a_fatal)
				Die();
			else {
				wetness += 10.0f;
				if (wetness >= wetnessThreshold)
					Die();
			}
		}
	}

	private void Die ()
	{
		dead = true;
		if (gameOverHUD != null)
			Instantiate (gameOverHUD);
	}
}
