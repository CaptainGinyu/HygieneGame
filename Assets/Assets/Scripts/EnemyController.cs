using UnityEngine;
using System.Collections;

public class EnemyController : NPCController
{
	public float damageThisGives;
	public float delayBetweenDamages;
	
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
			PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
			playerController.health -= damageThisGives;
			playerController.updateHealthText();
			timeUntilNextDamage = Time.time + delayBetweenDamages;
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			PlayerController playerController = other.gameObject.GetComponent<PlayerController>();

			if (Time.time > timeUntilNextDamage)
			{
				playerController.health -= damageThisGives;
				playerController.updateHealthText();
				timeUntilNextDamage = Time.time + delayBetweenDamages;
			}
		}
	}
}
