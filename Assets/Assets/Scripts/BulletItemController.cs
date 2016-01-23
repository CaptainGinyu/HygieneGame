using UnityEngine;
using System.Collections;

public class BulletItemController : Item
{
	public string whatThisAffects;
	public float howManySecondsThisItemLasts;
	public float speed;
	
	override protected void Start()
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x * speed, 0);
		Destroy(gameObject, howManySecondsThisItemLasts);
	}

	protected virtual void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy")
		{
			Killable enemy = other.gameObject.GetComponent<Killable>();
			if (enemy.nameOfThis == whatThisAffects)
			{
				Destroy(other.gameObject);
				GameControllerForLevel.score += enemy.pointsGivenIfKilled;
				GameControllerForLevel.recordedPoints += enemy.pointsGivenIfKilled;
				GameControllerForLevel.UpdateScoreText();
			}
			Destroy(gameObject);
		}
		else if (other.tag == "Other Collider")
		{
			Destroy(gameObject);
		}
	}
}
