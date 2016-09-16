using UnityEngine;
using System.Collections;

public class HealthAffector : MonoBehaviour
{
	public float healthGive;
	public float repeatDelay;

	private float timeUntilNextEffect;
	
	protected virtual void Start()
	{
		timeUntilNextEffect = 0.0f;
	}
	
	protected virtual void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			AffectPlayerHealth();
			timeUntilNextEffect = Time.time + repeatDelay;
		}
	}
	
	protected virtual void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			if (Time.time > timeUntilNextEffect)
			{
				AffectPlayerHealth();
				timeUntilNextEffect = Time.time + repeatDelay;
			}
		}
	}

	protected virtual void AffectPlayerHealth()
	{
		GameController.playerManager.AffectPlayerHealth(healthGive);
	}
}
