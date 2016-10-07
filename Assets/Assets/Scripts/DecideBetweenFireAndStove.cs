using UnityEngine;
using System.Collections;

public class DecideBetweenFireAndStove : MonoBehaviour
{
	void Start()
	{
		GameObject fireOrStove;
		
		if (GameController.stovePurchased)
		{
			fireOrStove = Resources.Load("stove") as GameObject;
		}
		else
		{
			fireOrStove = Resources.Load("campfire") as GameObject;
		}
		
		foreach (Transform child in transform)
		{
			GameObject instantiatedFireOrStove = Instantiate(fireOrStove);
			instantiatedFireOrStove.transform.parent = child;
			instantiatedFireOrStove.transform.position = child.position;
		}
	}
}
