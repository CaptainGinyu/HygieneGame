using UnityEngine;
using System.Collections;

public class GameControllerForLevel : GameController
{
	public int pointsToEndLevel;

	public static float recordedPoints;

	override protected void Start()
	{
		base.Start();
		recordedPoints = 0;
	}

	void Update()
	{
		if (recordedPoints >= pointsToEndLevel)
		{
			Application.LoadLevel("shopScreen");
		}
	}
}
