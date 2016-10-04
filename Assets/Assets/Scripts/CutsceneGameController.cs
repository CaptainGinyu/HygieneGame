using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CutsceneGameController : GameController
{
	public static string infoToShow;
	public static string imageToShow;

	public Text infoText;
	public RawImage imageArea;

	public static readonly string mosquitoBitYouText = "At night, while you were sleeping, you got bitten by mosquitos, so you lost health!";
	public static readonly string bednetProtectedYouText = "At night, while you were sleeping, your bed net protected you from mosquitos!";

	override protected void Start()
	{
		base.Start();

		if (infoToShow != null)
		{
			infoText.text = infoToShow;
		}

		if (infoToShow.Equals(mosquitoBitYouText))
		{
			GameController.playerManager.health -= 5;
			GameController.UpdateHealthText();
		}

		if (imageToShow != null)
		{
			imageArea.texture = Resources.Load(imageToShow) as Texture;
		}
	}
}
