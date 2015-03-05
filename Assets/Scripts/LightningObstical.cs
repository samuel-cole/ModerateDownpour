using UnityEngine;
using System.Collections;

public class LightningObstical : MonoBehaviour {

	public float lifeTimeMax = 2.0f;
	private float lifeTime;

	// Use this for initialization
	void Start () 
	{
		lifeTime = lifeTimeMax;
	}
	
	// Update is called once per frame
	void Update () 
	{
		lifeTime -= Time.deltaTime;
		if (lifeTime < 0 && GameObject.FindGameObjectWithTag("Player") != null) {
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().CheckCollision(false, true);
			DestroyObject(this.gameObject);
		}
	}
}
