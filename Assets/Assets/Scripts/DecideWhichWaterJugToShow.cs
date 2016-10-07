using UnityEngine;
using System.Collections;

public class DecideWhichWaterJugToShow : MonoBehaviour
{
	void Start()
	{
		GameObject waterJug;

		if (GameController.waterJugCapPurchased)
		{
			waterJug = Resources.Load("coveredWaterJug") as GameObject;
		}
		else
		{
			waterJug = Resources.Load("waterJug") as GameObject;
		}

		foreach (Transform child in transform)
		{
			GameObject instantiatedWaterJug = Instantiate(waterJug);
			instantiatedWaterJug.transform.parent = child;
			instantiatedWaterJug.transform.position = child.position;
		}
	}
}
