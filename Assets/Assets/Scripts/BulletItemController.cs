using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletItemController : Item
{
	public List<string> whatThisAffects;
	public float howManySecondsThisItemLasts;
	public float speed;
	
	protected virtual void Start()
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x * speed, 0);
		Destroy(gameObject, howManySecondsThisItemLasts);
	}

	protected virtual void OnTriggerEnter2D(Collider2D other)
	{
		Killable killable = other.gameObject.GetComponent<Killable>();
		if (killable != null) {
			foreach (string potentialVictim in whatThisAffects)
			{
				if (killable.nameOfThis.Equals(potentialVictim))
				{
					Destroy (other.gameObject);
					GameControllerForLevel.score += killable.pointsGivenIfKilled;
					GameControllerForLevel.recordedPoints += killable.pointsGivenIfKilled;
					GameControllerForLevel.UpdateScoreText();
					break;
				}
			}

			Destroy(gameObject);
		}
		else if (other.tag == "Enemy")
		{
			Destroy(gameObject);
		}
		else if (other.tag == "Other Collider")
		{
			Destroy(gameObject);
		}
	}
}
