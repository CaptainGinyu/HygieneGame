using UnityEngine;
using System.Collections;

public class AutoSpawner : MonoBehaviour
{
	public GameObject whatThisSpawns;
	public float delayBetweenSpawns;

	private Transform spawnPosition;
	private float nextSpawnTime;
	
	void Start()
	{
		spawnPosition = transform.Find("SpawnPosition");
		nextSpawnTime = 0.0f;
	}

	void Update()
	{
		if (Time.time > nextSpawnTime)
		{
			Instantiate(whatThisSpawns, spawnPosition.position, spawnPosition.rotation);
			nextSpawnTime = Time.time + delayBetweenSpawns;
		}
	}
}
