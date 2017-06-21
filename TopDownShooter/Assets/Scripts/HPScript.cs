using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HPScript : MonoBehaviour 
{
	public float hp = 1.0f;
	public DamageSource dmgSource;
	private const float MARGIN_OF_ERROR = 0.001f;

	public delegate void DiedHandler (object source, EventArgs e);
	public event DiedHandler Died;

	protected virtual void OnDeathAction ()
	{
		Destroy (gameObject);
	}

	void Update ()
	{
		if (hp <= 0f + MARGIN_OF_ERROR)
		{
			OnDeathAction ();
			OnDeath (this, new DiedEventArgs (dmgSource));
		}
	}

	protected void OnDeath (object source, EventArgs e)
	{
		if (Died != null) 
		{
			Died (source, e);
		}
	}
}
