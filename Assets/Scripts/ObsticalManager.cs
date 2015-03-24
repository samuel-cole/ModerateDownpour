using UnityEngine;
using System.Collections;

public class ObsticalManager : MonoBehaviour 
{

	private float m_obsticalCooldown;
	public GameObject lightning;
	public GameObject car;
	public GameObject car2;
	public GameObject frontObstical;
	private GameObject player;
	private int obsticalNumber;

	// Use this for initialization
	void Start () 
	{
		m_obsticalCooldown = Random.Range (5, 15);

		player = null;
	}
	
	// Update is called once per frame
	void Update () 
	{
		m_obsticalCooldown -= Time.deltaTime;

		if (player == null)
			player = GameObject.FindGameObjectWithTag ("Player");

		if (m_obsticalCooldown <= 0) 
		{
			//With ints, it seems as though Random.Range() includes the first number, but excludes the second, hence the second number here seeming higher than it should be.
			obsticalNumber = Random.Range (1, 4);

			AddObstical(obsticalNumber);

			m_obsticalCooldown = Random.Range (3, 10);
		}			
	}

	// Adds an obstical to the game world
	void AddObstical(int obsticalNumber) 
	{
		switch(obsticalNumber)
		{
		case 1:
			GameObject newLightning = (GameObject)Instantiate (lightning);
			newLightning.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z);
			break;
		case 2:
			if (Random.value < 0.5f)
			{
				GameObject newCar = (GameObject)Instantiate (car);
				newCar.transform.position = new Vector3(player.transform.position.x + 50, 0, 7);
			} else {
				GameObject newCar = (GameObject)Instantiate (car2);
				newCar.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
				newCar.transform.position = new Vector3(player.transform.position.x + 50, -2.7f, 12);
			}
			break;
		case 3:
			GameObject newFrontObstical = (GameObject)Instantiate (frontObstical);
			newFrontObstical.transform.position = new Vector3(player.transform.position.x + 50, 1, player.transform.position.z);
			break;
		default:
			Debug.Log("Invalid Obstical Number!");
			break;
		}
	}
}
