using UnityEngine;
using System.Collections;

public class BuildingScript : MonoBehaviour {

	private GameObject player;
	public float deleteDistance = 50;
	//Set this to true for objects that shouldn't count towards the houses passed count.
	public bool passed = false;
	//Set this to true if a building is to be generated.
	public bool generateBuilding = false;

	public GameObject fence;
	public GameObject building1;
	public GameObject window1;
	public GameObject window2;
	public GameObject door1;
	public GameObject door2;
	public GameObject steps1;
	public GameObject steps2;
	public GameObject kennel;

	// Use this for initialization
	void Start () {
		if (generateBuilding) {
			if (Random.value < 0.1f) {
				//Generate empty lot.
				GameObject newFence = Instantiate (fence);
				newFence.transform.position = transform.position;
				newFence.transform.parent = gameObject.transform;
				if (Random.value < 0.1f) {
					GameObject newKennel = Instantiate (kennel);
					if (Random.value < 0.5f) {
						newKennel.transform.position = transform.position + new Vector3(Random.value * 5.0f - 2.5f, 0.0f, -1.0f);
						newKennel.transform.Rotate(0, 180, 0);
					}
					else {
						newKennel.transform.position = transform.position + new Vector3(Random.value * 5.0f - 2.5f, 0.0f, 1.0f);
					}
					newKennel.transform.parent = gameObject.transform;
				}
			}
			else {
				//Building.
				GameObject newBuilding;
				newBuilding = Instantiate (building1);
				newBuilding.transform.localScale = new Vector3(1.0f, 0.8f, 1.0f);
				newBuilding.transform.position = transform.position;


				//Door
				GameObject newDoor;
				if (Random.value < 0.5f) {
					newDoor = Instantiate (door1);
					newDoor.transform.position = transform.position + new Vector3(0.0f, 2.2f, -5.0f);
					newDoor.transform.localScale = new Vector3(1.0f, 0.8f, 1.0f);
				} else {
					newDoor = Instantiate (door2);
					newDoor.transform.position = transform.position + new Vector3(-0.02f, 0.15f, -5.0f);
					newDoor.transform.localScale = new Vector3(0.89f, 0.8f, 1.0f);
				}

				newDoor.transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));


				//Steps
				GameObject newSteps;
				if (Random.value < 0.5f) {
					newSteps = Instantiate (steps1);
					newSteps.transform.position = transform.position + new Vector3(-0.12f, 0.2f, -5.05f);
				}
				else {
					newSteps = Instantiate (steps2);
					newSteps.transform.position = transform.position + new Vector3(-1.7f, 0.35f, -5.1f);
				}
				newSteps.transform.localScale = new Vector3(1.0f, 0.8f, 1.0f);
				newSteps.transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));

				//Windows
				GameObject newWindow1;
				GameObject newWindow2;
				GameObject newWindow3;
				GameObject newWindow4;
				GameObject newWindow5 = null;
				if (Random.value < 0.5f) {
					newWindow1 = Instantiate (window1);
					newWindow2 = Instantiate (window1);
					newWindow3 = Instantiate (window1);
					newWindow4 = Instantiate (window1);
					if (Random.value < 0.5f)
						newWindow5 = Instantiate (window1);

					newWindow1.transform.position = transform.position + new Vector3(-3.2f, 4.0f, -5.0f);
					newWindow2.transform.position = transform.position + new Vector3(3.2f,  4.0f, -5.0f);
					newWindow3.transform.position = transform.position + new Vector3(-3.2f, 11.0f, -5.0f);
					newWindow4.transform.position = transform.position + new Vector3(3.2f,  11.0f, -5.0f);
					if (newWindow5 != null)
						newWindow5.transform.position = transform.position + new Vector3(0.0f,  11.0f, -5.0f);
				}
				else {
					newWindow1 = Instantiate (window2);
					newWindow2 = Instantiate (window2);
					newWindow3 = Instantiate (window2);
					newWindow4 = Instantiate (window2);
					if (Random.value < 0.5f)
						newWindow5 = Instantiate (window2);
					
					newWindow1.transform.position = transform.position + new Vector3(-4.7f, 1.8f, -5.0f);
					newWindow2.transform.position = transform.position + new Vector3( 2.0f, 1.8f, -5.0f);
					newWindow3.transform.position = transform.position + new Vector3(-4.7f, 8.0f, -5.0f);
					newWindow4.transform.position = transform.position + new Vector3( 2.0f, 8.0f, -5.0f);
					if (newWindow5 != null)
						newWindow5.transform.position = transform.position + new Vector3(-1.3f,  8.0f, -5.0f);
				}
				newWindow1.transform.localScale = new Vector3(1.0f, 0.8f, 1.0f);
				newWindow1.transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));
				newWindow2.transform.localScale = new Vector3(1.0f, 0.8f, 1.0f);
				newWindow2.transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));
				newWindow3.transform.localScale = new Vector3(1.0f, 0.8f, 1.0f);
				newWindow3.transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));
				newWindow4.transform.localScale = new Vector3(1.0f, 0.8f, 1.0f);
				newWindow4.transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));
				if (newWindow5 != null) {
					newWindow5.transform.localScale = new Vector3(1.0f, 0.8f, 1.0f);
					newWindow5.transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));
				}

				//Attach everything to the one object. 
				newBuilding.transform.parent = gameObject.transform;
				newDoor.transform.parent     = gameObject.transform;
				newSteps.transform.parent    = gameObject.transform;
				newWindow1.transform.parent  = gameObject.transform;
				newWindow2.transform.parent  = gameObject.transform;
				newWindow3.transform.parent  = gameObject.transform;
				newWindow4.transform.parent  = gameObject.transform;
				if (newWindow5 != null)
					newWindow5.transform.parent = gameObject.transform;

			}
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (player == null)
			player = GameObject.FindGameObjectWithTag ("Player");
		else {
			if (gameObject.transform.position.x < player.transform.position.x - deleteDistance) {
				DestroyObject (this.gameObject);
			}
			else if (!passed && Mathf.Abs (player.transform.position.x - gameObject.transform.position.x) < 0.5f) {
				passed = true;
				player.GetComponent<PlayerScript>().housesPassed++;
			}
		}
	}
}
