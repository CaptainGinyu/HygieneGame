using UnityEngine;
using System.Collections;

public class ShopItem : MonoBehaviour
{
	public int price;
	public GameObject shopItemGameObject;

	void Start()
	{

	}

	public void Purchase()
	{
		Debug.Log("purchased");
		DontDestroyOnLoad(transform.gameObject);
		Application.LoadLevel("levelOne");
	}
}
