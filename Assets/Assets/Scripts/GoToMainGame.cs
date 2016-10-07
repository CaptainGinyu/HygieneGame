using UnityEngine;
using System.Collections;

public class GoToMainGame : MonoBehaviour
{
	public void ButtonClick()
	{
		Application.LoadLevel("mainGame");
	}
}
