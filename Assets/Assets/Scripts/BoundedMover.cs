using UnityEngine;
using System.Collections;

public class BoundedMover : Mover
{
	public Boundaries boundaries;

	private Vector2 scale;
	private float horizontalDirection;
	private float verticalDirection;

	override protected void Start()
	{
		base.Start();

		scale = new Vector2(Mathf.Abs(transform.localScale.x), Mathf.Abs(transform.localScale.y));
		if (movementSpeedX < 0)
		{
			transform.localScale = new Vector2(-scale.x, scale.y);
		}

		horizontalDirection = Mathf.Sign(transform.localScale.x);
		verticalDirection = Mathf.Sign(transform.localScale.y);

		rigidBody.position = new Vector2
		(
			Mathf.Clamp(rigidBody.position.x, boundaries.xMin + scale.x / 4, boundaries.xMax - scale.x / 4),
			Mathf.Clamp(rigidBody.position.y, boundaries.yMin + scale.y / 4, boundaries.yMax - scale.y / 4)
		);
	}

	void Update()
	{
		if ((movementSpeedX != 0) ||(movementSpeedY != 0))
		{
			rigidBody.velocity = new Vector2(horizontalDirection * movementSpeedX, verticalDirection * movementSpeedY);

			if ((horizontalDirection == -1 && rigidBody.position.x <= boundaries.xMin + scale.x / 4)
			    || (horizontalDirection == 1 && rigidBody.position.x >= boundaries.xMax - scale.x / 4))
			{
				horizontalDirection *= -1;
				transform.localScale = new Vector2(-transform.localScale.x, scale.y);
			}
			if ((verticalDirection == -1 && rigidBody.position.y <= boundaries.yMin + scale.y / 4)
			    || (verticalDirection == 1 && rigidBody.position.y >= boundaries.yMax - scale.y / 4))
			{
				verticalDirection *= -1;
			}
		}
	}
}
