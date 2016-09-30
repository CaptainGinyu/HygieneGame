using UnityEngine;
using System.Collections;

public class CutsceneContinue : MonoBehaviour
{
	public void Continue()
	{
		if (CutsceneGameController.infoToShow.Equals(CutsceneGameController.mosquitoBitYouText)
			|| CutsceneGameController.infoToShow.Equals(CutsceneGameController.mosquitoBitYouText))
		{
			Application.LoadLevel("mainGame");
		}
		else
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
		}
	}
}
