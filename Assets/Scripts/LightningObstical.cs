using UnityEngine;
using System.Collections;

public class LightningObstical : MonoBehaviour {

	public GameObject flash;

	public float intensityIncrease = 0.1f;

	public float lifeTimeMax = 2.0f;
	private float lifeTime;

	private GameObject player = null;
	private Light dirLight = null;

	// Use this for initialization
	void Start () 
	{
		lifeTime = lifeTimeMax;
	}
	
	// Update is called once per frame
	void Update () 
	{
		lifeTime -= Time.deltaTime;

		if (player == null) {
			player = GameObject.FindGameObjectWithTag ("Player");

			dirLight = GameObject.FindGameObjectWithTag ("DirectionalLight").GetComponent<Light> ();
			player.transform.FindChild ("LightningSound").GetComponent<AudioSource> ().Play ();

		} else if (lifeTime < 0) {
			player.GetComponent<PlayerScript> ().CheckCollision (false, true);
			dirLight.intensity = 1.0f;
			if (player.GetComponent<PlayerScript> ().IsAlive)
				Instantiate (flash);
			DestroyObject (this.gameObject);
		}

		if (dirLight != null)
			dirLight.intensity += intensityIncrease;
	}
}
