using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
	public float originalHealth;
	public ItemManager itemManager;
	public float health;

	private bool isWearingSandals;
	private GameObject playerInstance;
	private SpriteRenderer playerInstanceSpriteRenderer;

	void OnLevelWasLoaded(int level)
	{
		if (Application.loadedLevelName == "levelOne")
		{
			playerInstance =
				Instantiate
					(
						Resources.Load("Player") as GameObject,
						Vector2.zero,
						Quaternion.identity
					) as GameObject;
			playerInstanceSpriteRenderer = playerInstance.GetComponent<SpriteRenderer>();
		}
		else
		{
			Destroy(playerInstance);
		}
	}

	void Awake()
	{
		DontDestroyOnLoad(transform.gameObject);
	}

	void Start()
	{
		itemManager = gameObject.AddComponent<ItemManager>();
		GameObject soap = Resources.Load("soap") as GameObject;
		GameObject chlorine = Resources.Load("chlorineDrop") as GameObject;
		GameObject waterJugCap = Resources.Load("waterJugCap") as GameObject;
		itemManager.AddItem(soap.GetComponent<Item>(), 10);
		itemManager.AddItem(waterJugCap.GetComponent<Item>(), 10);
		itemManager.AddItem(chlorine.GetComponent<Item>(), 10);

		itemManager.DisplayCurrentItem();

		isWearingSandals = false;

		health = originalHealth;

		if (Application.loadedLevelName == "levelOne")
		{
			playerInstance =
				Instantiate
					(
						Resources.Load("Player") as GameObject,
						Vector2.zero,
						Quaternion.identity
					) as GameObject;
			playerInstanceSpriteRenderer = playerInstance.GetComponent<SpriteRenderer>();
		}

		GameController.UpdateScoreText();
		GameController.UpdateHealthText();
	}

	void Update()
	{
		if (health <= 0)
		{
			Destroy(playerInstance);
			Destroy(gameObject);
		}
	}

	public IEnumerator PlayerColorFlash(Color color)
	{
		playerInstanceSpriteRenderer.color = color;
		yield return new WaitForSeconds(1f);
		try
		{
			playerInstanceSpriteRenderer.color = Color.white;
		}
		catch(System.Exception)
		{

		}
	}
}
