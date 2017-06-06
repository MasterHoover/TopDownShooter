/* Author: Olivier Reid
 * 
 * Desc:
 * Shoot Projectiles toward a specific direction from this object.
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour 
{
	public Projectile projectile; // The projectile instantiated. 
	public float distanceOffset = 1f; // Distance offset between this object and the instantiated Projectile

	// Shoot a projectile toward a specific direction
	public void Shoot (Vector2 direction)
	{
		Shoot (direction, Projectile.Allegiance.None);
	}

	public void Shoot (Vector2 direction, Projectile.Allegiance allegiance)
	{
		if (projectile != null)
		{
			Vector3 spawnPos = transform.position + new Vector3 (direction.x, direction.y, 0f) * distanceOffset; // Set spawnPos
			Projectile instance = (Projectile) Instantiate (projectile, spawnPos, Quaternion.identity); // Instantiate the Projectile
			instance.MyAllegiance = allegiance;
			instance.Direction = direction; // Set direction to the Projectile. The script needs it to move toward the direction.
			instance.transform.up = new Vector3 (direction.x, direction.y, 0f); // Align projectile with direction
		}
	}
}
