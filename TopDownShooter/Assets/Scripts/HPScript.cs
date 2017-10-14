using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HPScript : MonoBehaviour 
{
	private float maxHP = 1.0f;
	private float hp;
	private const float MARGIN_OF_ERROR = 0.001f;
	public delegate void DeathHandler (object source, EventArgs e);
	public event DeathHandler Death;
	private bool wasDead = false;

	void Start ()
	{
		hp = maxHP;
	}

	protected virtual void OnDeath ()
	{
		if (Death != null)
		{
			Death (this, EventArgs.Empty);
		}
	}

	void Update ()
	{
		if (Dead && !wasDead)
		{
			wasDead = true;
			OnDeath ();
		}
		else if (!Dead && wasDead)
		{
			wasDead = false;
		}
	}

	public virtual void Damage (float amount)
	{
		hp -= amount;
	}

	public float MaxHP
	{
		set{ maxHP = value; }
	}

	private bool Dead
	{
		get{ return hp <= 0f + MARGIN_OF_ERROR; }
	}
}
