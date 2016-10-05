using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowFinalScore : MonoBehaviour
{
	protected Text finalScoreText;

	void Start()
	{
		finalScoreText = GetComponent<Text>();
		finalScoreText.text = "Your Final Score: " + GameController.score;
	}
}
