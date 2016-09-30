using UnityEngine;
using System.Collections;

public class ExitShop : MonoBehaviour
{
	public void Exit()
	{
		if (GameController.mosquitoNetPurchased)
		{
			CutsceneGameController.infoToShow = CutsceneGameController.bednetProtectedYouText;
			CutsceneGameController.imageToShow = "bednet";
		}
		else
		{
			CutsceneGameController.infoToShow = CutsceneGameController.mosquitoBitYouText;
			CutsceneGameController.imageToShow = "mosquitoBite";
		}

		Application.LoadLevel("cutscene");
	}
}
