using UnityEngine;
using System.Collections;

public class WaterCleaner : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D other)
	{
		WaterSource possibleWaterSource = other.gameObject.GetComponent<WaterSource>();

		if (possibleWaterSource != null)
		{
			if (!possibleWaterSource.isClean)
			{
				GameController.score += 2;
				GameController.UpdateScoreText();
			}
			possibleWaterSource.isClean = true;
			Destroy(gameObject);
		}
	}
}
