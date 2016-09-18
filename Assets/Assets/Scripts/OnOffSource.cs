using UnityEngine;
using System.Collections;

public class OnOffSource : MonoBehaviour
{
	public string nameOfThis;
	public float delayLowerBound;
	public float delayUpperBound;	
	public GameObject attachment;

	private float nextSwitchingTime;

	void Start()
	{
		nextSwitchingTime = 0.0f;
	}

	void Update()
	{
		if (Time.time > nextSwitchingTime)
		{
			attachment.SetActive(!attachment.activeSelf);
			if (delayLowerBound < delayUpperBound)
			{
				nextSwitchingTime = Time.time + Random.Range(delayLowerBound, delayUpperBound);
			}
			else
			{
				nextSwitchingTime = Time.time + delayLowerBound;
			}
		}
	}
}
