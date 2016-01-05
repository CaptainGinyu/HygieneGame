using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public static float score = 0;
	public static int numKills;

	private static Text healthText;
	private static Text scoreText;

	public static PlayerManager playerManager;
	
	void Start()
	{
		if (playerManager == null)
		{
			GameObject playerManagerGameObject =
				Instantiate
					(
						Resources.Load("PlayerManager") as GameObject,
						Vector2.zero,
						Quaternion.identity
					) as GameObject;
			playerManager = playerManagerGameObject.GetComponent<PlayerManager>();
		}

		numKills = 0;

		healthText = GameObject.Find("Health Text").GetComponent<Text>();
		scoreText = GameObject.Find("Score Text").GetComponent<Text>();

		UpdateHealthText();
		UpdateScoreText();
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
		healthText.text = "Health: " + playerManager.health.ToString();
	}

	public static void UpdateScoreText()
	{
		scoreText.text = "Score: " + score.ToString();
	}
}
