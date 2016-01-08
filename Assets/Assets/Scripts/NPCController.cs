using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour
{
	public string nameOfThis;
	public float movementSpeedX;
	public float movementSpeedY;
	public Boundaries boundaries;

	private int horizontalDirection;
	private int verticalDirection;

	private Rigidbody2D npcRigidBody;

	private Vector2 scale;

	protected virtual void Start()
	{
		if (transform.localScale.x > 0)
		{
			horizontalDirection = 1;
		}
		else
		{
			horizontalDirection = -1;
		}
		verticalDirection = 1;

		npcRigidBody = GetComponent<Rigidbody2D>();

		scale = transform.localScale;
	}

	void Update()
	{
		PerformNPCMovement();
	}

	void PerformNPCMovement()
	{
		if ((movementSpeedX != 0) || (movementSpeedY != 0))
		{
			npcRigidBody.velocity = new Vector2(horizontalDirection * movementSpeedX, verticalDirection * movementSpeedY);

			if ((horizontalDirection == -1 && npcRigidBody.position.x <= boundaries.xMin + scale.x / 4)
			    || (horizontalDirection == 1 && npcRigidBody.position.x >= boundaries.xMax - scale.x / 4))
			{
				horizontalDirection *= -1;
				transform.localScale = new Vector2(-transform.localScale.x, scale.y);
			}
			if ((verticalDirection == -1 && npcRigidBody.position.y <= boundaries.yMin + scale.y / 4)
			    || (verticalDirection == 1 && npcRigidBody.position.y >= boundaries.yMax - scale.y / 4))
			{
				verticalDirection *= -1;
			}
		}
	}
}
