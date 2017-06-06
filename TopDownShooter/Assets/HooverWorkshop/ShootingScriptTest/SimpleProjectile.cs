/* Author: Olivier Reid
 * 
 * Desc:
 * Test the implementation of a Projectile. This projectile simply moves toward the direction, and SelfDestruct after a delay.
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleProjectile : Projectile 
{
	public float duration = 4f;	// Duration before SelfDestructing

	void Start ()
	{
		//Invoke ("SelfDestruct", duration); // Invoke the SelfDestruct
	}

	// The implemented function (parent forces the implementation of this function)
	protected override void Behavior ()
	{
		transform.Translate (new Vector3 (Direction.x, Direction.y, 0f) * speed * Time.deltaTime, Space.World); // Move toward direction.
	}

	// Destroy this object
	void SelfDestruct ()
	{
		Destroy (gameObject);
	}

	protected override void EnemyEnter (Enemy enemy)
	{
		Debug.Log ("Hit [" + enemy.displayName + "] by " + damage + " damage!");
		if (enemy.HPScript != null)
		{
			enemy.HPScript.hp -= damage;
		}
		else
		{
			Debug.LogWarning ("Enemy[" + enemy.name + "] doesn't have an HPScript.");
 		}
		Destroy (gameObject);
	}
}
