using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HPScript : MonoBehaviour 
{
	public float maxHP = 1.0f;
	private float hp;
	private const float MARGIN_OF_ERROR = 0.001f;

	void Awake ()
	{
		hp = maxHP;
	}

	protected virtual void OnDeathAction ()
	{
		Destroy (gameObject);
	}

	void Update ()
	{
		if (hp <= 0f + MARGIN_OF_ERROR)
		{
			OnDeathAction ();
		}
	}

	public virtual void Damage (float amount)
	{
		hp -= amount;
	}
}
