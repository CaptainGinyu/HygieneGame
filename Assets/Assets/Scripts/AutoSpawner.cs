using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AutoSpawner : MonoBehaviour
{
	public string nameOfThis;
	public GameObject whatThisSpawns;
	public float delayLowerBound;
	public float delayUpperBound;

	protected List<Transform> possibleSpawnPositions;
	protected Transform spawnPosition;
	private float nextSpawnTime;
	
	protected virtual void Start()
	{
		possibleSpawnPositions = new List<Transform>();

		foreach (Transform child in transform)
		{
			possibleSpawnPositions.Add(child);
		}

		nextSpawnTime = 0.0f;
	}
	
	protected virtual void Update()
	{
		spawnPosition = possibleSpawnPositions[Random.Range(0, possibleSpawnPositions.Count)];

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
