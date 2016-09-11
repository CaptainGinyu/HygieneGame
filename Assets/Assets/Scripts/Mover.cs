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

	public void ChangeDirection(bool changeVertical)
	{
		if (changeVertical)
		{
			rigidBody.velocity = new Vector2(rigidBody.velocity.x, -rigidBody.velocity.y);
		}
		else
		{
			rigidBody.velocity = new Vector2(-rigidBody.velocity.x, rigidBody.velocity.y);
			transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
		}
	}
}
