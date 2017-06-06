/* Author: Olivier Reid
 * 
 * Desc:
 * Script that provides the direction from a referenced object to this object
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionPoint : MonoBehaviour 
{
	public Transform reference; // The referenced object

	// Provides the Direction (in 2D) between this object and the referenced object
	public Vector2 Direction 
	{
		get
		{
			if (reference != null)
			{
				Vector3 dir = transform.position - reference.position;
				return new Vector2 (dir.x, dir.y);
			}
			return Vector2.zero;
		}
	}

	// Line between both object (to view the direction provided)
	void OnDrawGizmos ()
	{
		if (reference != null)
		{
			Gizmos.color = Color.blue;
			Gizmos.DrawLine (new Vector3 (transform.position.x, transform.position.y, reference.position.z), reference.position);
		}
	}
}
