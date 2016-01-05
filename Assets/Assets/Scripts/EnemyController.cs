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
			HurtThePlayer();
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			if (Time.time > timeUntilNextDamage)
			{
				HurtThePlayer();
			}
		}
	}

	void HurtThePlayer()
	{
		GameController.playerManager.health -= damageThisGives;
		GameController.UpdateHealthText();
		timeUntilNextDamage = Time.time + delayBetweenDamages;
		StartCoroutine(GameController.playerManager.PlayerColorFlash(Color.red));
	}
}
