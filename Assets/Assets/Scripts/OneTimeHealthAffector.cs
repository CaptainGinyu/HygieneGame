using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OneTimeHealthAffector : HealthAffector
{
	public float howManySecondsThisLasts;
	public List<string> autoSpawnerThisCanGoThrough;

	override protected void Start()
	{
		base.Start();
		Destroy(gameObject, howManySecondsThisLasts);
	}

	override protected void OnTriggerEnter2D(Collider2D other)
	{
		base.OnTriggerEnter2D(other);

		AutoSpawner possibleAutoSpawner = other.gameObject.GetComponent<AutoSpawner>();

		if (possibleAutoSpawner != null && autoSpawnerThisCanGoThrough.Contains(possibleAutoSpawner.nameOfThis))
		{
			return;
		}

		Destroy(gameObject);
	}

	override protected void OnTriggerStay2D(Collider2D other)
	{
		//should not go here anyway, since gameObject will get destroyed
	}
}
