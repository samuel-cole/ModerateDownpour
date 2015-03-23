using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class BackgroundSpawn : MonoBehaviour {

	public GameObject buildingPrefab;
	public GameObject playerPrefab;
	public GameObject groundPrefab;
	public GameObject closeBackground;
	public GameObject farBackground;
	public GameObject footpath;

	//I should have done all of this with a list of objects, but not enough time to refactor.
	public float spawnDistanceFromPlayer;
	public float spawnTime;
	private float spawnTimeCurrent;

	public float groundSpawnDistanceFromPlayer;
	public float groundSpawnTime;
	private float groundSpawnTimeCurrent;

	public  float closeBackgroundSpawnDistanceFromPlayer;
	public  float closeBackgroundSpawnTime;
	private float closeBackgroundSpawnTimeCurrent;

	public  float farBackgroundSpawnDistanceFromPlayer;
	public  float farBackgroundSpawnTime;
	private float farBackgroundSpawnTimeCurrent;

	public  float footpathSpawnDistanceFromPlayer;
	public  float footpathSpawnTime;
	private float footpathSpawnTimeCurrent;

	//public List<GameObject> prefabs;
	//public List<Vector3> spawnDistances;
	//public List<float> spawnTimes;
	//private List<float> spawnTimeCurrents;


	
	private GameObject player;


	// Use this for initialization
	void Start () {
		spawnTimeCurrent = spawnTime;
		groundSpawnTimeCurrent = groundSpawnTime;
		closeBackgroundSpawnTimeCurrent = closeBackgroundSpawnTime;
		farBackgroundSpawnTimeCurrent = farBackgroundSpawnTime;

		player = (GameObject)Instantiate (playerPrefab);
		player.transform.position = new Vector3 (0, 0, 13);
		player.GetComponent<PlayerScript> ().IsAlive = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<PlayerScript> ().IsAlive) {

			spawnTimeCurrent -= Time.deltaTime;
			groundSpawnTimeCurrent -= Time.deltaTime;
			closeBackgroundSpawnTimeCurrent -= Time.deltaTime;
			farBackgroundSpawnTimeCurrent -= Time.deltaTime;
			footpathSpawnTimeCurrent -= Time.deltaTime;

			if (spawnTimeCurrent <= 0) {

				spawnTimeCurrent = spawnTime;
				//if (Random.value > 0.9f)
				{
					GameObject newBuilding = (GameObject)Instantiate (buildingPrefab);
					newBuilding.transform.position = new Vector3 (player.transform.position.x + spawnDistanceFromPlayer, 0, 20.0f);
				}
			}
			if (groundSpawnTimeCurrent <= 0) {
				groundSpawnTimeCurrent = groundSpawnTime;
				GameObject newGround = (GameObject)Instantiate (groundPrefab);
				newGround.transform.position = new Vector3 (player.transform.position.x + groundSpawnDistanceFromPlayer, -0.01f, player.transform.position.z);
			}
			if (closeBackgroundSpawnTimeCurrent <= 0) {
				closeBackgroundSpawnTimeCurrent = closeBackgroundSpawnTime;
				GameObject newBackground = (GameObject)Instantiate (closeBackground);
				newBackground.transform.position = new Vector3 (player.transform.position.x + closeBackgroundSpawnDistanceFromPlayer, 3.0f, 30.0f);
			}
			if (farBackgroundSpawnTimeCurrent <= 0) {
				farBackgroundSpawnTimeCurrent = farBackgroundSpawnTime;
				GameObject newBackground = (GameObject)Instantiate (farBackground);
				newBackground.transform.position = new Vector3 (player.transform.position.x + farBackgroundSpawnDistanceFromPlayer, 12.0f, 50.0f);
			}

			if (footpathSpawnTimeCurrent <= 0) {
				footpathSpawnTimeCurrent = footpathSpawnTime;
				GameObject newFootpath = (GameObject)Instantiate (footpath);
				newFootpath.transform.position = new Vector3 (player.transform.position.x + footpathSpawnDistanceFromPlayer, 0.0f, 6.0f);
			}
		}
	}
}
