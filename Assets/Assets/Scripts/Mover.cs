using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	public float movementSpeedX;
	public float movementSpeedY;

	protected Rigidbody2D rigidBody;

	protected virtual void Start()
	{
		rigidBody = GetComponent<Rigidbody2D>();
		rigidBody.velocity = new Vector2(movementSpeedX, movementSpeedY);
	}
}
