using UnityEngine;
using System.Collections;

public class FlashScript : MonoBehaviour {

	public float lifeTime = 0.01f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		lifeTime -= Time.deltaTime;

		if (lifeTime <= 0) {
			DestroyObject(gameObject);
		}
	}
}
