using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets._2D;

public class GameController : MonoBehaviour
{
	public static float score = 0;
	public static int numKills;

	private static Text healthText;
	private static Text scoreText;

	public static GameObject player;
	public static PlayerController playerController;
	
	void Start()
	{
		if (player == null)
		{
			player = Resources.Load("Player") as GameObject;
			playerController = player.GetComponent<PlayerController>();
		}
		Debug.Log("playerController: " + PlayerController.itemManager);
		if (Application.loadedLevelName == "levelOne")
		{
			GameObject playerInstance =
				Instantiate
				(
					player,
					new Vector2(0, 0),
					Quaternion.identity
				) as GameObject;

			GameObject.Find("Main Camera").GetComponent<Camera2DFollow>().target = playerInstance.transform;
		}

		numKills = 0;

		healthText = GameObject.Find("Health Text").GetComponent<Text>();
		scoreText = GameObject.Find("Score Text").GetComponent<Text>();

		GameController.UpdateHealthText();
		GameController.UpdateScoreText();
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
