using UnityEngine;
using System.Collections;

public class AutoSpawner : MonoBehaviour
{
	public string nameOfThis;
	public GameObject whatThisSpawns;
	public float delayLowerBound;
	public float delayUpperBound;
	
	protected Transform spawnPosition;
	private float nextSpawnTime;
	
	protected virtual void Start()
	{
		spawnPosition = transform.Find("SpawnPosition");
		nextSpawnTime = 0.0f;
	}
	
	protected virtual void Update()
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
