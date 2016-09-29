using UnityEngine;
using System.Collections;

public class FoodHealthAffector : HealthAffector
{
	public float howManySecondsThisLasts;
	public DirtyMaker[] getsDirtyFrom;
	private Color dirtyColor;

	override protected void Start()
	{
		base.Start();
		dirtyColor = new Color(0.4f, 0.2f, 0.0f);
		Destroy(gameObject, howManySecondsThisLasts);
	}

	override protected void OnTriggerEnter2D(Collider2D other)
	{
		base.OnTriggerEnter2D(other);

		DirtyMaker possibleDirtyMaker = other.GetComponent<DirtyMaker>();

		if (possibleDirtyMaker != null) 
		{
			foreach (DirtyMaker dirtyMaker in getsDirtyFrom)
			{
				if (dirtyMaker.nameOfThis.Equals(possibleDirtyMaker.nameOfThis))
				{
					healthGive = -Mathf.Abs(healthGive);
					gameObject.GetComponent<SpriteRenderer>().color = dirtyColor;
					return;
				}
			}
		}
	}

	override protected void OnTriggerStay2D(Collider2D other)
	{
		//should not go here anyway
	}

	override protected void AffectPlayerHealth()
	{
		base.AffectPlayerHealth();
		Destroy(gameObject);
	}
}
