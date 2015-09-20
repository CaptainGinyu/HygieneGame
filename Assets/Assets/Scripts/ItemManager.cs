using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class ItemAndQuantity
{
	public GameObject item;
	public int quantity;

	public ItemAndQuantity(GameObject itemToAdd, int quantityToAdd)
	{
		item = itemToAdd;
		quantity = quantityToAdd;
	}
}

public class ItemManager : MonoBehaviour
{
	public List<ItemAndQuantity> itemList;

	private Image itemImageDisplayer;
	private Text itemQuantityDisplayer;
	private Sprite emptyImage;
	private static int currentItemIndex;
	private static bool currentItemIndexInitialized;

	private static List<ItemAndQuantity> storedItemList;

	private bool changeWeaponPressed;

	void Start()
	{
		if (storedItemList == null)
		{
			storedItemList = itemList;
		}
		else
		{
			itemList = storedItemList;
		}

		itemImageDisplayer = transform.Find("Displayed Item").GetComponent<Image>();
		itemQuantityDisplayer = transform.Find("Displayed Item Quantity").GetComponent<Text>();
		emptyImage = itemImageDisplayer.sprite;
		if (currentItemIndexInitialized)
		{
			DisplayCurrentItem();
		}
		else
		{
			if (itemList.Count > 0)
			{
				currentItemIndex = 0;
				DisplayCurrentItem();
			}
			else
			{
				currentItemIndex = -1;
			}

			currentItemIndexInitialized = true;
		}
		
		changeWeaponPressed = false;
	}
	
	// Update is called once per frame
	void Update()
	{
		if (Input.GetAxisRaw("ChangeWeapon") > 0)
		{
			if (!changeWeaponPressed)
			{
				changeWeaponPressed = true;

				if (itemList.Count > 0)
				{
					currentItemIndex = (currentItemIndex + 1) % itemList.Count;
					DisplayCurrentItem();
				}
			}
		}
		else if (Input.GetAxisRaw("ChangeWeapon") == 0)
		{
			changeWeaponPressed = false;
		}
	}

	public void addItem(GameObject item, int quantity)
	{
		if (item.GetComponent<Item>() != null && quantity > 0)
		{
			itemList.Add(new ItemAndQuantity(item, quantity));
		}
	}

	public void removeItem(ItemAndQuantity item)
	{
		int listIndex = itemList.IndexOf(item);

		itemList.Remove(item);

		currentItemIndex = listIndex - 1;
		if (itemList.Count > 0 && currentItemIndex < 0)
		{
			currentItemIndex = itemList.Count - 1;
		}
	}

	public int getCurrentItemIndex()
	{
		return currentItemIndex;
	}

	public void DisplayCurrentItem()
	{
		if (currentItemIndex >= 0)
		{
			ItemAndQuantity currItemAndQuantity = itemList[currentItemIndex];
			itemImageDisplayer.sprite = currItemAndQuantity.item.GetComponent<Item>().spriteToShowInItemManager;
			itemQuantityDisplayer.text = currItemAndQuantity.quantity.ToString();
		}
		else
		{
			itemImageDisplayer.sprite = emptyImage;
			itemQuantityDisplayer.text = "";
		}
	}
}
