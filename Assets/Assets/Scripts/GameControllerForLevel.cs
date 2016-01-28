using UnityEngine;
using System.Collections;

public class GameControllerForLevel : GameController
{
	public int pointsToEndLevel;
	public bool shopInBetween;
	public string nameOfNextScene;

	public bool dirtyHandAvailable;
	public bool foodAvailable;
	public bool smokeAvailable;
	public bool poopAndFliesAvailable;
	public bool mosquitosAvailable;

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
			if (shopInBetween)
			{
				ExitShop.nameOfNextLevel = nameOfNextScene;
				Application.LoadLevel("shopScreen");
			}
			else
			{
				Application.LoadLevel(nameOfNextScene);
			}
		}
	}
}
