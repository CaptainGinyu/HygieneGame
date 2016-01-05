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
	private static List<ItemAndQuantity> itemList;

	private Image itemImageDisplayer;
	private Text itemQuantityDisplayer;
	private Sprite emptyImage;
	private static int currentItemIndex;

	private bool changeWeaponPressed;

	void OnLevelWasLoaded(int level)
	{
		itemImageDisplayer = GameObject.Find("Displayed Item").GetComponent<Image>();
		itemQuantityDisplayer = GameObject.Find("Displayed Item Quantity").GetComponent<Text>();
		DisplayCurrentItem();
	}

	void Awake()
	{
		itemList = new List<ItemAndQuantity>();
		
		itemImageDisplayer = GameObject.Find("Displayed Item").GetComponent<Image>();
		itemQuantityDisplayer = GameObject.Find("Displayed Item Quantity").GetComponent<Text>();
		emptyImage = itemImageDisplayer.sprite;
		
		currentItemIndex = -1;
	}

	void Start()
	{
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
		if (quantity > 0)
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

					DisplayCurrentItem();
					return;
				}
			}
			itemList.Add(new ItemAndQuantity(item, quantity));
			if (currentItemIndex < 0)
			{
				currentItemIndex = 0;
			}

			DisplayCurrentItem();
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

		DisplayCurrentItem();
	}

	public Item DispenseCurrentItem()
	{
		Item itemToDispense = null;

		if (currentItemIndex >= 0)
		{
			itemToDispense = itemList[currentItemIndex].item;
			itemList[currentItemIndex].quantity--;

			if (itemList[currentItemIndex].quantity <= 0)
			{
				itemList.RemoveAt(currentItemIndex);
				currentItemIndex--;
				if (itemList.Count > 0 && currentItemIndex < 0)
				{
					currentItemIndex = itemList.Count - 1;
				}
			}

			DisplayCurrentItem();
		}

		return itemToDispense;
	}

	public int NumberOfItemTypes()
	{
		return itemList.Count;
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
