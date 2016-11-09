using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//This handles the behavior of a shop item button in the shop scene

public class ShopItem : MonoBehaviour
{
	private Text statusTextDisplayer; //This is text that tells you why your buy attempt failed if it did

	public int price; //The amount you need to pay to buy the shop item controlled by this button
	public Item shopItem; //The shop item that is being sold

	//Unity components that hold text and image
	private Text priceText;
	private Text nameText;
	private Image itemImage;

	IEnumerator currentCoroutine; //to be used when temporarily displaying text in the statusTextDisplayer

	void Start()
	{
		//Finds Unity components in the scene
		statusTextDisplayer = GameObject.Find("Status Text").GetComponent<Text>();
		priceText = transform.Find("Item Price").GetComponent<Text>();
		nameText = transform.Find("Item Name").GetComponent<Text>();
		itemImage = transform.Find("Item Image").GetComponent<Image>();

		//Tells the Unity components what text and image to display
		priceText.text = price.ToString();
		nameText.text = shopItem.itemName;
		itemImage.sprite = shopItem.itemImage;
	}

	//TemporarilyDisplayTextCoroutine is used by TemporarilyDisplayText (see below)
	IEnumerator TemporarilyDisplayTextCoroutine(string textToDisplay, float howLongToDisplay)
	{
		if (statusTextDisplayer != null)
		{
			statusTextDisplayer.text = textToDisplay;
		}

		yield return new WaitForSeconds(howLongToDisplay);

		if (statusTextDisplayer != null)
		{
			statusTextDisplayer.text = "";
		}

		if (currentCoroutine != null)
		{
			currentCoroutine = null;
		}
	}

	//Shows text (specified by textToDisplay) for a certain amount of time (specified by howLongToDisplay)
	void TemporarilyDisplayText(string textToDisplay, float howLongToDisplay)
	{
		if (currentCoroutine != null)
		{
			StopCoroutine(currentCoroutine);
		}
		currentCoroutine = TemporarilyDisplayTextCoroutine(textToDisplay, howLongToDisplay);
		StartCoroutine(currentCoroutine);
	}

	//Controls what happens when you try to purchase the shop item 
	public void Purchase()
	{
		//The following handle cases for when you already have purchased an item that you are only allowed to have one of
		if (shopItem.itemName == "sandals" && GameController.playerManager.getIsWearingSandals())
		{
			TemporarilyDisplayText("You already have sandals", 5.0f);
			Debug.Log ("You already have sandals!");
		}
		else if (shopItem.itemName == "bednet" && GameController.mosquitoNetPurchased)
		{
			TemporarilyDisplayText("You already have a bednet", 5.0f);
			Debug.Log ("You already have a bednet!");
		}
		else if (shopItem.itemName == "water filter" && GameController.waterFilterPurchased)
		{
			TemporarilyDisplayText("You already have a water filter", 5.0f);
			Debug.Log ("You already have a water filter!");
		}
		else if (shopItem.itemName == "water jug caps" && GameController.waterJugCapPurchased)
		{
			TemporarilyDisplayText("You already have water jug caps", 5.0f);
			Debug.Log ("You already have water jug caps!");
		}
		else if (shopItem.itemName == "stove" && GameController.stovePurchased)
		{
			TemporarilyDisplayText("You already have a stove", 5.0f);
			Debug.Log ("You already have a stove!");
		}

		//This case handles a successful purchase
		else if (GameController.score >= price)
		{
			Debug.Log("purchased");
			GameController.score -= price;
			GameController.UpdateScoreText();
			if (shopItem.itemName == "sandals")
			{
				GameController.playerManager.toggleWearingSandals(true);
			}
			else if (shopItem.itemName == "water filter")
			{
				GameController.waterFilterPurchased = true;
			}
			else if (shopItem.itemName == "bednet")
			{
				GameController.mosquitoNetPurchased = true;
			}
			else if (shopItem.itemName == "water jug caps")
			{
				GameController.waterJugCapPurchased = true;
			}
			else if (shopItem.itemName == "stove")
			{
				GameController.stovePurchased = true;
			}
			else
			{
				GameController.playerManager.itemManager.AddItem(shopItem, 1);
			}
		}

		//This case is for when you do not have enough money to make the purchase
		else
		{
			TemporarilyDisplayText("Not enough money!", 5.0f);
			Debug.Log("not enough money");
		}
	}
}
