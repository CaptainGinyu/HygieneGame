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
		itemImage.sprite = shopItem.spriteToShowInItemManager;
	}

	public void Purchase()
	{
		if (GameController.score >= price)
		{
			Debug.Log("purchased");
			GameController.score -= price;
			GameController.UpdateScoreText();
			PlayerController.itemManager.AddItem(shopItem, 1);
			PlayerController.itemManager.DisplayCurrentItem();
		}
		else
		{
			Debug.Log("not enough money");
		}
	}
}
