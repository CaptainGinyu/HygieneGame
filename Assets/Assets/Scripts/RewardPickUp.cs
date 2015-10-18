using UnityEngine;
using System.Collections;

public class RewardPickUp : MonoBehaviour
{
	public float healthBoost;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
			playerController.health += healthBoost;
			playerController.updateHealthText();
			Destroy(gameObject);
		}
	}
}
