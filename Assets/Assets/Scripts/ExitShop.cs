using UnityEngine;
using System.Collections;

public class ExitShop : MonoBehaviour
{
	public static string nameOfNextLevel;

	public void Exit()
	{
		Application.LoadLevel("levelOne");
	}
}
