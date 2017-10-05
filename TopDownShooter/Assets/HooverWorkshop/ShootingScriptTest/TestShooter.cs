/* Author: Olivier Reid
 * 
 * Desc:
 * Script that uses both a ShootingScript and a DirectionPoint.
 * 		ShootingScript: To test the Shoot(Vector2) function.
 * 		DirectionPoint: Uses the DirectionPoint's direction to be used as a ShootingDirection.
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShooter : MonoBehaviour 
{
	public ShootingInterface shootingScript;
	public DirectionPoint directionPoint;
	public Projectile.Allegiance allegiance;
	public float speed = 15f;

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.KeypadPlus))
		{
			if (shootingScript != null && directionPoint != null)
			{
				shootingScript.Shoot (directionPoint.Direction, speed, allegiance); // Shoots toward the direction given from the DirectionPoint
			}
		}
	}
}
