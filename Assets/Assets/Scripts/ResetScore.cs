using UnityEngine;
using System.Collections;

public class ResetScore : MonoBehaviour
{
	void Start()
	{
		GameController.score = 0;
		GameController.waterFilterPurchased = false;
		GameController.stovePurchased = false;
		GameController.mosquitoNetPurchased = false;
		GameController.waterJugCapPurchased = false;
	}
}
