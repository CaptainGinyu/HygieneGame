using UnityEngine;
using System.Collections;

public class DecideWhichPondToShow : MonoBehaviour
{
	void Start()
	{
		GameObject pond;

		if (GameController.waterFilterPurchased)
		{
			pond = Instantiate(Resources.Load("pondFiltered") as GameObject);
		}
		else
		{
			pond = Instantiate(Resources.Load("pond") as GameObject);
		}

		pond.transform.parent = transform;
		pond.transform.position = transform.position;
	}
}
