using UnityEngine;
using System.Collections;

public class OneTimeHealthAffector : HealthAffector
{
	public float howManySecondsThisLasts;

	override protected void Start()
	{
		base.Start();
		Destroy(gameObject, howManySecondsThisLasts);
	}

	override protected void OnTriggerEnter2D(Collider2D other)
	{
		base.OnTriggerEnter2D(other);
		Destroy(gameObject);
	}

	override protected void OnTriggerStay2D(Collider2D other)
	{
		//should not go here anyway, since gameObject will get destroyed
	}
}
