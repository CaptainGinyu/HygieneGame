using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControllerForLevel : GameController
{
	public int pointsToEndLevel;

	public static float recordedPoints;

	private Text pointsToEndLevelText;

	override protected void Start()
	{
		base.Start();
		recordedPoints = 0;

		pointsToEndLevelText = GameObject.Find("Points to End Level Text").GetComponent<Text>();
		pointsToEndLevelText.text = "Points to End Level: " + pointsToEndLevel;
	}

	void Update()
	{
		if (recordedPoints >= pointsToEndLevel)
		{
			Application.LoadLevel("shopScreen");
		}
	}
}
