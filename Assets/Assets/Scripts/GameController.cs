using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public static float score = 0;

	private static Text healthText;
	private static Text scoreText;

	public static PlayerManager playerManager;
	
	protected virtual void Start()
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

		healthText = GameObject.Find("Health Text").GetComponent<Text>();
		scoreText = GameObject.Find("Score Text").GetComponent<Text>();

		UpdateHealthText();
		UpdateScoreText();
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
