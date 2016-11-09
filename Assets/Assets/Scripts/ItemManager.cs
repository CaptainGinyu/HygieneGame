using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

//ItemAndQuantity is exactly what it sounds like: It's a grouping of an item with a number value
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

//ItemManager is what manages the player's items
public class ItemManager : MonoBehaviour
{
	private static List<ItemAndQuantity> itemList; //List of items and their corresponding quantities

	private Image itemImageDisplayer; //Unity component that displays image (in this case, an image of the item)
	private Text itemQuantityDisplayer; //Unity component that displays text (in this case, text that shows a number)
	private Sprite emptyImage; //represents a white space image
	private static int currentItemIndex; //number that represents the item's place (ie. 0th place, 1st place, etc.)

	private bool changeWeaponPressed; //tells you if the user pressed the change weapon button

	//Shows the current item and quantity when the level loads
	void OnLevelWasLoaded(int level)
	{
		itemImageDisplayer = GameObject.Find("Displayed Item").GetComponent<Image>();
		itemQuantityDisplayer = GameObject.Find("Displayed Item Quantity").GetComponent<Text>();
		DisplayCurrentItem();
	}

	//prepares the item list at the start of the game
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
		//initialize the changeWeaponPressed variable to false because user hasn't pressed anything yet
		//since this point is the start of the game
		changeWeaponPressed = false;
	}
	
	void Update()
	{
		//if user pressed the change weapon button, switch to the next item in the list
		//and if the item in the list is already the last item, go back to the first item in the list (ie. wrap around).
		//then store a true value in teh changeWeaponPressed variable
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

		//otherwise, store a false value in changeWeaponPressed because the user didn't press the change weapon button
		else if (Input.GetAxisRaw("ChangeWeapon") == 0)
		{
			changeWeaponPressed = false;
		}
	}

	//Adds items to our item list
	//The item parameter specifies what type of item we want to add (ie. soap, chlorine), and quantity specifies how many of that item we
	//want to add
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

	//Removes a single item from our item list
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

	//Tells you what item is the player currently has selected
	public Item GetCurrentItem()
	{
		if (currentItemIndex >= 0)
		{
			return itemList[currentItemIndex].item;
		}

		return null;
	}

	//Tells you the number of item types in our item list
	public int NumberOfItemTypes()
	{
		return itemList.Count;
	}

	//Show the current item
	public void DisplayCurrentItem()
	{
		if (currentItemIndex >= 0)
		{
			ItemAndQuantity currItemAndQuantity = itemList[currentItemIndex];
			itemImageDisplayer.sprite = currItemAndQuantity.item.itemImage;
			itemQuantityDisplayer.text = currItemAndQuantity.quantity.ToString();
		}
		else
		{
			itemImageDisplayer.sprite = emptyImage;
			itemQuantityDisplayer.text = "";
		}
	}
}
