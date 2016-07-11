using UnityEngine;
using System.Collections;

public class EnemyThatKillsFood : MonoBehaviour
{
	protected virtual void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Killable Food")
		{
			Destroy(other.gameObject);
		}
	}
}
