using UnityEngine;
using System.Collections;

public class WaterSource : AutoSpawner
{
	public bool isClean;

	private HealthAffector healthEffectOfWater;
	private Mover waterDropMover;

	private SpriteRenderer waterSourceSpriteRenderer;
	private SpriteRenderer waterDropSpriteRenderer;

	private Color dirtyColor;

	override protected void Start()
	{
		healthEffectOfWater = whatThisSpawns.GetComponent<HealthAffector>();
		waterDropMover = whatThisSpawns.GetComponent<Mover>();

		waterSourceSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		waterDropSpriteRenderer = whatThisSpawns.GetComponent<SpriteRenderer>();

		dirtyColor = new Color(0.4f, 0.2f, 0.0f);

		base.Start();
	}

	override protected void Update()
	{
		if (isClean)
		{
			waterSourceSpriteRenderer.color = Color.white;
			waterDropSpriteRenderer.color = Color.white;
			healthEffectOfWater.healthGive = Mathf.Abs(healthEffectOfWater.healthGive);
		}
		else
		{
			waterSourceSpriteRenderer.color = dirtyColor;
			waterDropSpriteRenderer.color = dirtyColor;
			healthEffectOfWater.healthGive = -Mathf.Abs(healthEffectOfWater.healthGive);
		}

		if (Random.Range(0, 100) < 50)
		{
			waterDropMover.movementSpeedX = Random.Range(2.0f, 3.0f);
		}
		else
		{
			waterDropMover.movementSpeedX = -Random.Range(2.0f, 3.0f);
		}

		if (Random.Range(0, 100) < 50)
		{
			waterDropMover.movementSpeedY = Random.Range(2.0f, 3.0f);
		}
		else
		{
			waterDropMover.movementSpeedY = -Random.Range(2.0f, 3.0f);
		}

		base.Update();
	}
}
