using UnityEngine;
using System.Collections;

public class BackgroundSpawn : MonoBehaviour {

	public GameObject buildingPrefab;
	public GameObject playerPrefab;
	public GameObject groundPrefab;

	public GameObject startHud;

	public float spawnDistanceFromPlayer;
	public float spawnTime;
	private float spawnTimeCurrent;

	public float groundSpawnDistanceFromPlayer;
	public float groundSpawnTime;
	private float groundSpawnTimeCurrent;
	
	private GameObject player;
	private uint buildingsPassed = 0;


	// Use this for initialization
	void Start () {
		spawnTimeCurrent = spawnTime;
		groundSpawnTimeCurrent = groundSpawnTime;
		player = (GameObject)Instantiate (playerPrefab);
		player.transform.position = new Vector3 (0, 0, 0);
		player.GetComponent<PlayerScript> ().IsAlive = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<PlayerScript> ().IsAlive) {

			spawnTimeCurrent -= Time.deltaTime;
			groundSpawnTimeCurrent -= Time.deltaTime;

			if (spawnTimeCurrent <= 0) {
				++buildingsPassed;
				spawnTimeCurrent = spawnTime;
				GameObject newBuilding = (GameObject)Instantiate (buildingPrefab);
				newBuilding.transform.position = new Vector3 (player.transform.position.x + spawnDistanceFromPlayer, player.transform.position.y + newBuilding.transform.localScale.y / 2 - player.transform.localScale.y, 20.0f);
			}
			if (groundSpawnTimeCurrent <= 0) {
				groundSpawnTimeCurrent = groundSpawnTime;
				GameObject newGround = (GameObject)Instantiate (groundPrefab);
				newGround.transform.position = new Vector3 (player.transform.position.x + groundSpawnDistanceFromPlayer, player.transform.position.y - player.transform.localScale.y, player.transform.position.z);
			}
		}
	}
}
