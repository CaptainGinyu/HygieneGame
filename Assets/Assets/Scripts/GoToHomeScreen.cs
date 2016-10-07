using UnityEngine;
using System.Collections;

public class GoToHomeScreen : MonoBehaviour
{
	public void ButtonClick()
	{
		Application.LoadLevel("homeScreen");
	}
}
