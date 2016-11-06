using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AutoSpawner : MonoBehaviour
{
	public string nameOfThis;
	public GameObject whatThisSpawns;

	//These values specify the range  in which a random number is chosen from, where the random number represents the time
	//that something will spawn (where that "something" is whatever is stored in the whatThisSpawns variable)
	public float delayLowerBound;
	public float delayUpperBound;

	protected List<Transform> possibleSpawnPositions;
	protected Transform spawnPosition;
	private float nextSpawnTime;
	
	protected virtual void Start()
	{
		//The possible spawn positions are specified manually within the Unity editor.  They are children of whatever
		//game object this script is attached to

		//Create a list to store the possible spawn positions
		possibleSpawnPositions = new List<Transform>();

		//Add all possible spawn positions to the list
		foreach (Transform child in transform)
		{
			possibleSpawnPositions.Add(child);
		}

		nextSpawnTime = 0.0f; //Make the first spawn happen immediately
	}

	//When it is time to spawn, pick a random spawn position out of our list of possible spawn positions
	//and then spawn one thing at that position (where the thing is whatever is stored in the whatThisSpawns variable)
	//and then pick a new random spawn time
	protected virtual void Update()
	{
		if (Time.time > nextSpawnTime)
		{
			spawnPosition = possibleSpawnPositions[Random.Range(0, possibleSpawnPositions.Count)];

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
