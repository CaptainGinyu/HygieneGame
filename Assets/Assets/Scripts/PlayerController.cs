using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets._2D;

[System.Serializable]
public class Boundaries
{
	public float xMin;
	public float xMax;
	public float yMin;
	public float yMax;
}

public class PlayerController : MonoBehaviour
{
	public float walkingSpeed;
	public float firingDelayTime;
	public Boundaries boundaries;
	
	private bool isFacingRight;
	
	private Rigidbody2D playerRigidBody;
	
	private Animator playerAnimator;
	private Vector2 scale;
	
	private Transform shotSpawnPosition;
	private float nextFireTime;
	
	private Camera2DFollow camera2DFollow;
	
	void Start() 
	{
		if (transform.localScale.x >= 0)
		{
			isFacingRight = true;
		}
		else
		{
			isFacingRight = false;
		}

		playerRigidBody = GetComponent<Rigidbody2D>();
		
		playerAnimator = GetComponent<Animator>();
		scale = new Vector2(Mathf.Abs(transform.localScale.x), Mathf.Abs(transform.localScale.y));
		
		shotSpawnPosition = transform.Find("ShotSpawnPosition");
		nextFireTime = 0.0f;
		
		camera2DFollow = GameObject.Find("Main Camera").AddComponent<Camera2DFollow>();
		camera2DFollow.target = transform;
	}
	
	void OnDestroy()
	{
		Destroy(camera2DFollow);
	}
	
	void FixedUpdate()
	{
		HandleWalking();
		HandleFiring();
	}
	
	void HandleFiring()
	{
		float fireButtonValue = Input.GetAxisRaw("Fire1");
		
		if (fireButtonValue > 0 && Time.time > nextFireTime)
		{
			if (GameController.playerManager.itemManager.NumberOfItemTypes() > 0)
			{
				Item currItemInItemManager = GameController.playerManager.itemManager.getCurrentItem();
				
				if (currItemInItemManager is BulletItemController)
				{
					Item itemSpawned =
						Instantiate
							(
								GameController.playerManager.itemManager.DispenseCurrentItem(),
								shotSpawnPosition.position,
								shotSpawnPosition.rotation
								)
							as Item;
					
					if (!isFacingRight)
					{
						Vector2 itemScale = itemSpawned.transform.localScale;
						itemSpawned.transform.localScale = new Vector2(-itemScale.x, itemScale.y);
					}
				}
				
				nextFireTime = Time.time + firingDelayTime;
			}
		}
	}
	
	void HandleWalking()
	{
		float moveHoriz = Input.GetAxisRaw("Horizontal");
		float moveVert = Input.GetAxisRaw("Vertical");
		Vector2 movement = new Vector2(moveHoriz, moveVert);
		
		playerRigidBody.velocity = movement * walkingSpeed;
		
		playerRigidBody.position = new Vector2
			(
				Mathf.Clamp(playerRigidBody.position.x, boundaries.xMin + scale.x / 4, boundaries.xMax - scale.x / 4),
				Mathf.Clamp(playerRigidBody.position.y, boundaries.yMin + scale.y / 4, boundaries.yMax - scale.y / 4)
			);

		if (moveHoriz > 0)
		{
			isFacingRight = true;
			transform.localScale = new Vector2(scale.x, scale.y);
		}
		else if (moveHoriz < 0)
		{
			isFacingRight = false;
			transform.localScale = new Vector2(-scale.x, scale.y);
		}
		
		if (moveHoriz != 0 || moveVert != 0)
		{
			playerAnimator.SetBool("isMoving", true);
		}
		else
		{
			playerAnimator.SetBool("isMoving", false);
		}
	}
}