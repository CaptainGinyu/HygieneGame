using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
	public int price;
	public Item shopItem;

	private Text priceText;
	private Text nameText;
	private Image itemImage;

	void Start()
	{
		priceText = transform.Find("Item Price").GetComponent<Text>();
		nameText = transform.Find("Item Name").GetComponent<Text>();
		itemImage = transform.Find("Item Image").GetComponent<Image>();
		priceText.text = price.ToString();
		nameText.text = shopItem.itemName;
		itemImage.sprite = shopItem.itemImage;
	}

	public void Purchase()
	{
		if (shopItem.itemName == "sandals" && GameController.playerManager.getIsWearingSandals())
		{
			Debug.Log ("You already have sandals!");
		}
		else if (shopItem.itemName == "bednet" && GameController.mosquitoNetPurchased)
		{
			Debug.Log ("You already have a bednet!");
		}
		else if (shopItem.itemName == "water filter" && GameController.waterFilterPurchased)
		{
			Debug.Log ("You already have a water filter!");
		}
		else if (shopItem.itemName == "water jug caps" && GameController.waterJugCapPurchased)
		{
			Debug.Log ("You already have water jug caps!");
		}
		else if (shopItem.itemName == "stove" && GameController.stovePurchased)
		{
			Debug.Log ("You already have a stove!");
		}
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
		else
		{
			Debug.Log("not enough money");
		}
	}
}
