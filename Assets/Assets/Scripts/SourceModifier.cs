using UnityEngine;
using System.Collections;

public class SourceModifier : BulletItemController
{
	public float localX;
	public float localY;
	public bool turnSourceEnemyGood;
	public bool destroySource;

	override protected void Start()
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x * speed, 0);
		Invoke("DestroyInvocation", howManySecondsThisItemLasts);
	}

	override protected void OnTriggerEnter2D(Collider2D other)
	{
		AutoSpawner autoSpawner = other.gameObject.GetComponent<AutoSpawner>();
		if (autoSpawner != null)
		{
			if (autoSpawner.nameOfThis == whatThisAffects)
			{
				CancelInvoke("DestroyInvocation");
				transform.parent = autoSpawner.transform;
				GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
				transform.localPosition = new Vector2(localX, localY);
				if (destroySource)
				{
					Destroy(autoSpawner.gameObject);
					Destroy(this);
					return;
				}
				if (turnSourceEnemyGood)
				{
					HealthAffector healthAffector = other.gameObject.GetComponent<HealthAffector>();
					if (healthAffector != null)
					{
						healthAffector.healthGive = Mathf.Abs(healthAffector.healthGive);
					}
					HealthAffector spawnedHealthAffector = autoSpawner.whatThisSpawns.GetComponent<HealthAffector>();
					if (spawnedHealthAffector != null)
					{
						spawnedHealthAffector.healthGive = Mathf.Abs(spawnedHealthAffector.healthGive);
					}

				}
				else
				{
					Destroy(autoSpawner);
				}
				Destroy(this);
			}
			else
			{
				Destroy(gameObject);
			}
		}
		else if ((other.tag == "Enemy") || (other.tag == "Other Collider"))
		{
			Destroy(gameObject);
		}
	}

	void DestroyInvocation()
	{
		Destroy(gameObject);
	}
}
