using UnityEngine;
using System.Collections;

public class DirectionFacingMover : Mover
{

	override protected void Start()
	{
		base.Start();
		gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Rad2Deg * Mathf.Atan2(movementSpeedY, movementSpeedX)));
	}
}
