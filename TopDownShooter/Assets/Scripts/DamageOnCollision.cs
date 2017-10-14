using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour 
{
	private float damage;
	private string[] tagList;

	void OnTriggerEnter2D (Collider2D col)
	{
		bool foundIt = false;
		for (int i = 0; !foundIt && i < tagList.Length; i++)
		{
			if (col.tag.Equals (tagList [i]))
			{
				Debug.Log ("[" + col.name + "] was hit by [" + name + "]. " + damage + " DAMAGE.");
				HPScript s = col.gameObject.GetComponent<HPScript> ();
				if (s != null)
				{
					s.Damage (damage);
				}
			}
		}
	}

	public float Damage 
	{
		set{ damage = value; }
	}

	public string[] TagList
	{
		set{ tagList = value; }
	}
}
