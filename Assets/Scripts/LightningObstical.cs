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
			//ParticleSystem particleSystem = player.transform.FindChild("Clouds").GetComponent<ParticleSystem>();
			//ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleSystem.maxParticles];
			//int length = particleSystem.GetParticles(particles);
			//
			//for (uint i = 0; i < length; ++i) {
			//	float colour;
			//	if (Random.value < 0.5)
			//		colour = Random.value * 50;
			//	else
			//		colour = 0;
			//	particles[i].color = new Color(colour, colour, 0);
			//}
			//particleSystem.SetParticles(particles, length);
			dirLight = GameObject.FindGameObjectWithTag("DirectionalLight").GetComponent<Light>();
			player.transform.FindChild("LightningSound").GetComponent<AudioSource>().Play();

		} else if (lifeTime < 0) {
			player.GetComponent<PlayerScript>().CheckCollision(false, true);
			dirLight.intensity = 1.0f;
			if (player.GetComponent<PlayerScript>().IsAlive)
				Instantiate (flash);
			DestroyObject(this.gameObject);
		}

		if (dirLight != null)
			dirLight.intensity += intensityIncrease;
	}
}
