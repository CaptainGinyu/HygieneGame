using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
	public float originalHealth;
	public ItemManager itemManager;
	public float health;

	private GameObject playerInstance;

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
		itemManager.AddItem(soap.GetComponent<Item>(), 10);
		itemManager.AddItem(chlorine.GetComponent<Item>(), 10);

		itemManager.DisplayCurrentItem();

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
		}

		GameController.UpdateScoreText();
		GameController.UpdateHealthText();
	}

	void Update()
	{
		if (health <= 0)
		{
			Destroy(playerInstance);

		}
	}
}
