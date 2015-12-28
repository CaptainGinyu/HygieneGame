using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ItemAndQuantity
{
	public Item item;
	public int quantity;

	public ItemAndQuantity(Item itemToAdd, int quantityToAdd)
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
		if (itemList == null)
		{
			itemList = new List<ItemAndQuantity>();
		}

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

	public void AddItem(Item item, int quantity)
	{
		if (item.GetComponent<Item>() != null && quantity > 0)
		{
			foreach (ItemAndQuantity itemAndQuantity in itemList)
			{
				if (itemAndQuantity.item == item)
				{
					itemAndQuantity.quantity += quantity;
					if (currentItemIndex < 0)
					{
						currentItemIndex = 0;
					}
					return;
				}
			}
			itemList.Add(new ItemAndQuantity(item, quantity));
			if (currentItemIndex < 0)
			{
				currentItemIndex = 0;
			}
		}
	}

	public void RemoveItem(ItemAndQuantity item)
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
			itemImageDisplayer.sprite = currItemAndQuantity.item.spriteToShowInItemManager;
			itemQuantityDisplayer.text = currItemAndQuantity.quantity.ToString();
		}
		else
		{
			itemImageDisplayer.sprite = emptyImage;
			itemQuantityDisplayer.text = "";
		}
	}
}
