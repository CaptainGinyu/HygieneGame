using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
	public float originalHealth;

	private bool isFacingRight;

	private Rigidbody2D playerRigidBody;

	private Animator playerAnimator;
	private Vector2 scale;

	private ItemManager itemManager;
	private Transform shotSpawnPosition;
	private float nextFireTime;

	public static float health;
	private static bool beenInitalized;

	void Start() 
	{
		isFacingRight = true;
		
		playerRigidBody = GetComponent<Rigidbody2D>();

		playerAnimator = GetComponent<Animator>();
		scale = transform.localScale;

		itemManager = GameObject.Find("Item Display Area").GetComponent<ItemManager>();
		shotSpawnPosition = transform.Find("ShotSpawnPosition");
		nextFireTime = 0.0f;

		if (!beenInitalized)
		{
			health = originalHealth;
			beenInitalized = true;
		}
	}

	void Update()
	{
		if (health <= 0)
		{
			Destroy(gameObject);
			Destroy(GameObject.Find("Main Camera").GetComponent<UnityStandardAssets._2D.Camera2DFollow>());
		}
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
			int currentItemIndex = itemManager.getCurrentItemIndex();

			if (currentItemIndex >= 0)
			{
				GameObject item =
					Instantiate
					(
						itemManager.itemList[currentItemIndex].item,
						shotSpawnPosition.position,
						shotSpawnPosition.rotation
					)
					as GameObject;

				if (!isFacingRight)
				{
					Vector2 itemScale = item.transform.localScale;
					item.transform.localScale = new Vector2(-itemScale.x, itemScale.y);
				}

				itemManager.itemList[currentItemIndex].quantity--;


				if (itemManager.itemList[currentItemIndex].quantity <= 0)
				{
					itemManager.removeItem(itemManager.itemList[currentItemIndex]);
				}

				itemManager.DisplayCurrentItem();
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
