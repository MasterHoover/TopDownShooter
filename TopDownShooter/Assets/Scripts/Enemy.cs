using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
	public string displayName = "UNNAMED";
	private HPScript hpScript;
	private DamageOnCollision onCollisionDamageScript;
	public float maxHP = 2f;
	public float onCollisionDamage = 1f;
	public string[] onCollisionDamageTags = { "Player" };

	void Awake ()
	{
		hpScript = GetComponent<HPScript> ();
		if (hpScript == null)
		{
			hpScript = gameObject.AddComponent<HPScript> ();
		}
		hpScript.MaxHP = maxHP;
		hpScript.Death += OnDeath;

		onCollisionDamageScript = gameObject.GetComponent<DamageOnCollision> ();
		if (onCollisionDamageScript == null)
		{
			onCollisionDamageScript = gameObject.AddComponent<DamageOnCollision> ();
		}
		onCollisionDamageScript.Damage = onCollisionDamage;
		onCollisionDamageScript.TagList = onCollisionDamageTags;
	}

	protected virtual void OnDeath (object source, System.EventArgs e)
	{
		Debug.Log ("[" + gameObject.name + "] just died.");
		Destroy (gameObject);
	}

	public HPScript HPScript
	{
		get{return hpScript;}
	}
}
