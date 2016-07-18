using UnityEngine;
using System.Collections;

public class PoopHealthAffector : HealthAffector
{
	override protected void AffectPlayerHealth()
	{
		if (GameController.playerManager.getIsWearingSandals())
		{
			return;
		}
		base.AffectPlayerHealth();
	}
}
