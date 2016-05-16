using UnityEngine;
using System.Collections;

public class AutoSpawner : MonoBehaviour
{
	public string nameOfThis;
	public GameObject whatThisSpawns;
	public float delayLowerBound;
	public float delayUpperBound;
	
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
			if (delayLowerBound < delayUpperBound)
			{
				nextSpawnTime = Time.time + Random.Range(delayLowerBound, delayUpperBound);
			}
			else
			{
				nextSpawnTime = Time.time + delayLowerBound;
			}
		}
	}
}
