﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class Boundaries
{
	public float xMin;
	public float xMax;
	public float yMin;
	public float yMax;
}

public class GameController : MonoBehaviour
{
	public static float score = 0;

	private static Text healthText;
	private static Text scoreText;

	public static bool waterJugCapPurchased;
	public static bool waterFilterPurchased;
	public static bool mosquitoNetPurchased;
	public static bool stovePurchased;

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
