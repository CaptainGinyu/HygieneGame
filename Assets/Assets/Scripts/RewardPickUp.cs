﻿using UnityEngine;
using System.Collections;

public class RewardPickUp : Item
{
	public float healthBoost;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			PlayerController.health += healthBoost;
			GameController.UpdateHealthText();
			Destroy(gameObject);
		}
	}
}
