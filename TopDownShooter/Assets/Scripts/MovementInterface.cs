using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInterface : MonoBehaviour 
{
	private Rigidbody2D rb;

	void Awake ()
	{
		rb = GetComponent<Rigidbody2D> ();
		if (rb == null) 
		{
			Debug.LogWarning ("[" + name + "]/MovingInterface : No Rigidbody2D was found on gameObject. Collisions will be ignored.");
		}
	}

	public void Move (Vector2 direction, float speed)
	{
		direction.Normalize ();
		if (rb != null) 
		{
			Vector2 currentPos = VectorFunc.ConvertTo2DVec (transform.position);
			Debug.DrawRay (currentPos, direction, Color.blue);
			Debug.Log ((direction * speed * Time.deltaTime).magnitude);
			rb.position = (currentPos + direction * speed * Time.deltaTime);
		} 
		else 
		{
			transform.Translate (direction * speed * Time.deltaTime, Space.World);
		}
	}
}
