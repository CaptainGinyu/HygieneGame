using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public static float score = 0;
	public static int numKills;

	private static Text healthText;
	private static Text scoreText;
	public static ItemManager itemManager;
	
	void Start()
	{
		numKills = 0;

		healthText = GameObject.Find("Health Text").GetComponent<Text>();
		scoreText = GameObject.Find("Score Text").GetComponent<Text>();

		UpdateScoreText();
		UpdateHealthText();
	}

	void Update()
	{
		if (Application.loadedLevelName == "levelOne")
		{
			if (numKills > 0)
			{
				Application.LoadLevel("shopScreen");
			}
		}
	}

	public static void UpdateHealthText()
	{
		healthText.text = "Health: " + PlayerController.health.ToString();
	}

	public static void UpdateScoreText()
	{
		scoreText.text = "Score: " + score.ToString();
	}
}
