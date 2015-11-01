using UnityEngine;
using System.Collections;

public class ExitShop : MonoBehaviour
{
	public void Exit()
	{
		Application.LoadLevel("levelOne");
	}
}
