using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatar : MonoBehaviour 
{
	private HPScript hpScript;
	public float maxHP = 1f;

	void Awake ()
	{
		hpScript = GetComponent<HPScript> ();
		if (hpScript == null)
		{
			hpScript = gameObject.AddComponent<HPScript> ();
		}
		hpScript.MaxHP = maxHP;
		hpScript.Death += OnDeath;
	}

	void OnDeath (object source, System.EventArgs e)
	{
		Debug.Log ("YOU DIED. START OR ENTER TO CONTINUE.");
		Destroy (gameObject);
	}
}
