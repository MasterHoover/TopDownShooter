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
	public float aggroDistance = 10f;
	public bool showAggroDistance;
	private EnemyVision visionScript;
	private MovementInterface moveScript;
	public float moveSpeed = 5f; 

	void Awake ()
	{
		ComponentSetup ();
	}

	protected virtual void ComponentSetup ()
	{
		moveScript = GetComponent<MovementInterface> ();
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
		visionScript = GetComponent<EnemyVision> ();
		if (visionScript == null)
		{
			visionScript = gameObject.AddComponent<EnemyVision> ();
		}
		visionScript.AggroDistance = aggroDistance;
		visionScript.AvatarDetected += OnAvatarDetected;
		visionScript.LostVision += OnLostVision;
		visionScript.SeeingAvatar += OnSeeingAvatar;
	}

	protected virtual void OnDeath (object source, System.EventArgs e)
	{
		Debug.Log ("[" + gameObject.name + "] just died.");
		Destroy (gameObject);
	}

	protected virtual void OnAvatarDetected ()
	{
		
	}

	protected virtual void OnLostVision ()
	{
		
	}

	protected virtual void OnSeeingAvatar ()
	{
		Charge ();
	}

	private void Charge ()
	{
		GameObject a = AvatarRespawner.Instance.Avatar;
		if (a != null)
		{
			Debug.Log ("Charging");
			moveScript.Move (VectorFunc.ConvertTo2DVec (a.transform.position - transform.position), moveSpeed);
		}
	}

	void OnDrawGizmos ()
	{
		if (showAggroDistance)
		{
			Color c = Color.red;
			c.a = 0.4f;
			Gizmos.color = c;
			Gizmos.DrawSphere (transform.position, aggroDistance);
		}
	}

	public HPScript HPScript
	{
		get{return hpScript;}
	}
}
