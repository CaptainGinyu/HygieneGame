using UnityEngine;
using System.Collections;

//This script contains code that mostly deals with the player's health/things related to the player's health.
//It also contains miscellaneous code for dealing with initializing the player at the start of the game.

public class PlayerManager : MonoBehaviour
{
	public float originalHealth; //This is a value that represents the health the player begins with
	public ItemManager itemManager; //This controls the user's (shootable) items; See ItemManager.cs
	public float health; //The player's current health, which, of course, changes over time depending on what the player bumps into

	private bool isWearingSandals; //Whether the player is wearing sandals
	private GameObject playerInstance; //The thing that is in the game: contains the player's image, all this code, and the ability to control the player, all "packaged up"
	private SpriteRenderer playerInstanceSpriteRenderer; //Unity uses SpriteRenderers to display images, which, in this case, is the player's image

	void OnLevelWasLoaded(int level)
	{
		//If we are in the main game (ie. not in the shop screen or some other screen), then show the player
		if (Application.loadedLevelName == "mainGame")
		{
			//if/else case that shows sandal-wearing player or non-sandal-wearing player depending on whether we
			//have bought sandals or not

			//Show the version of the player that is not wearing sandals
			if (!isWearingSandals)
			{
				playerInstance =
					Instantiate
						(
							Resources.Load("Player") as GameObject,
							Vector2.zero,
							Quaternion.identity
						) as GameObject;
			}
			//Show the version of the player that is wearing sandals
			else
			{
				playerInstance =
					Instantiate
						(
							Resources.Load("PlayerWithSandals") as GameObject,
							Vector2.zero,
							Quaternion.identity
						) as GameObject;
			}
			playerInstanceSpriteRenderer = playerInstance.GetComponent<SpriteRenderer>();
		}
		//Otherwise, do not show the player
		else
		{
			Destroy(playerInstance);
		}
	}

	//This is needed in Unity to preserve the player's various properties (ie. health, items) across scene changes
	void Awake()
	{
		DontDestroyOnLoad(transform.gameObject);
	}

	void Start()
	{
		//Initializing the player's items
		itemManager = gameObject.AddComponent<ItemManager>();
		GameObject soap = Resources.Load("soap") as GameObject;
		GameObject chlorine = Resources.Load("chlorineDrop") as GameObject;
		itemManager.AddItem(soap.GetComponent<Item>(), 10);
		itemManager.AddItem(chlorine.GetComponent<Item>(), 10);

		itemManager.DisplayCurrentItem(); //showing the first item on screen

		isWearingSandals = false; //telling the game that the player doesn't have sandals yet

		health = originalHealth; //setting current health to the base health

		//if we are in the main game, show the player on screen
		if (Application.loadedLevelName == "mainGame")
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

		//show the initial score and health
		GameController.UpdateScoreText();
		GameController.UpdateHealthText();
	}

	void Update()
	{
		//Remove the player and go to game over screen when player dies
		//except during the middle of a cutscene, in which we would wait for the user to finish looking at the cutscene before
		//going to the game over screen
		if (health <= 0)
		{
			Destroy(playerInstance);
			Destroy(gameObject);
			if (!Application.loadedLevelName.Equals("cutscene"))
			{
				Application.LoadLevel("gameOverScreen");
			}
		}
	}

	//Flashes the player a certain color based on whatever the coder passes in as the color parameter
	//ex. If I, as the coder, pass in the color red, then the player will flash red for one second.
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

	//Adds health to the player, which can be positive or negative, and then updates the health text
	//Obviously, adding negative health means losing health, and that will cause the player to flash red
	public void AffectPlayerHealth(float healthAmount)
	{
		health += healthAmount;
		if (healthAmount < 0)
		{
			StartCoroutine(PlayerColorFlash(Color.red));
		}

		GameController.UpdateHealthText();
	}

	//Tells you if the player is wearing sandals
	public bool getIsWearingSandals()
	{
		return isWearingSandals;
	}

	//Sets the isWearingSandals variable
	public void toggleWearingSandals(bool sandalsOnOrOff)
	{
		isWearingSandals = sandalsOnOrOff;
	}
}
