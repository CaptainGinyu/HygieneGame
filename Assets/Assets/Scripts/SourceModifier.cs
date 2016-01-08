using UnityEngine;
using System.Collections;

public class SourceModifier : BulletItemController
{
	public float localX;
	public float localY;

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
				Destroy(autoSpawner);
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
