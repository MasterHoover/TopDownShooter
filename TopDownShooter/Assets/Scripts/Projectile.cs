/* Author: Olivier Reid
 * 
 * Desc:
 * Projectile script, parent to any Projectiles
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour 
{
	protected Vector2 direction; // Hold the direction of the shot set by the shooter.\
	protected float damage;
	protected float speed = 3f;
	protected Allegiance allegiance = Allegiance.None;

	public enum Allegiance
	{
		None,
		Good,
		Bad
	}
		
	protected void Update ()
	{
		Behavior (); // Plays the implemented behavior
	}

	protected abstract void Behavior (); // Function that needs to be implemented by every Projectiles (abstract)
	// Holds the Behavior of every Projectiles (the way it moves for example)

	public Vector2 Direction
	{
		protected get
		{
			return direction;
		}
		set
		{
			direction = value;
		}
	}

	public float Damage
	{
		get{return damage;}
		set{damage = value;}
	}

	public Allegiance MyAllegiance
	{
		get{return allegiance;}
		set{allegiance = value;}
	}

	public float Speed 
	{
		get {return speed;}
		set { speed = value; }
	}
}
