using UnityEngine;
using System.Collections;

public class WalkingAnimationController : MonoBehaviour
{
	private Rigidbody2D walkerRigidBody;
	private Animator walkerAnimator;
	private Vector2 scale;

	void Start()
	{
		walkerRigidBody = GetComponent<Rigidbody2D>();
		walkerAnimator = GetComponent<Animator>();
		scale = new Vector2(Mathf.Abs(transform.localScale.x), Mathf.Abs(transform.localScale.y));
	}

	void Update()
	{
		Vector2 currVelocity = walkerRigidBody.velocity;

		float moveHoriz = currVelocity.x;
		float moveVert = currVelocity.y;

		if (moveHoriz > 0)
		{
			transform.localScale = new Vector2(scale.x, scale.y);
		}
		else if (moveHoriz < 0)
		{
			transform.localScale = new Vector2(-scale.x, scale.y);
		}

		if (moveHoriz != 0 || moveVert != 0)
		{
			walkerAnimator.SetBool("isMoving", true);
		}
		else
		{
			walkerAnimator.SetBool("isMoving", false);
		}
	}
}
