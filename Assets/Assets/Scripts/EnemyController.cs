using UnityEngine;
using System.Collections;

public class EnemyController : NPCController
{
	public float damageThisGives;
	public float delayBetweenDamages;
	public float pointsGivenIfKilled;
	
	private float timeUntilNextDamage;
	
	override protected void Start()
	{
		base.Start();

		timeUntilNextDamage = 0.0f;
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			PlayerController.health -= damageThisGives;
			GameController.UpdateHealthText();
			timeUntilNextDamage = Time.time + delayBetweenDamages;
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			if (Time.time > timeUntilNextDamage)
			{
				PlayerController.health -= damageThisGives;
				GameController.UpdateHealthText();
				timeUntilNextDamage = Time.time + delayBetweenDamages;
			}
		}
	}
}
