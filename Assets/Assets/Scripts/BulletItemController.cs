using UnityEngine;
using System.Collections;

public class BulletItemController : Item
{
	public string whatThisKills;
	public float howManySecondsThisItemLasts;
	public float speed;
	
	void Start()
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x * speed, 0);
		Destroy(gameObject, howManySecondsThisItemLasts);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy")
		{
			if (other.gameObject.GetComponent<EnemyController>().nameOfThis == whatThisKills)
			{
				Destroy(other.gameObject);
			}
			Destroy(gameObject);
		}
		else if (other.tag == "Other Collider")
		{
			Destroy(gameObject);
		}
	}
}
