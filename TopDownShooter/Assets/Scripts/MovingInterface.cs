using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingInterface : MonoBehaviour 
{
	private float speed = 1f;
	private Rigidbody2D rb;
	private bool foundRigidbody;

	void Awake ()
	{
		rb = GetComponent<Rigidbody2D> ();
		foundRigidbody = rb != null ? true : false;
		if (!foundRigidbody) 
		{
			Debug.LogWarning ("[" + name + "]/MovingInterface : No Rigidbody2D was found on gameObject. Collisions will be ignored.");
		}
	}

	public void Move (Vector2 direction)
	{
		if (foundRigidbody) 
		{
			Vector2 currentPos = new Vector2 (transform.position.x, transform.position.y);
			rb.MovePosition (currentPos + direction * speed * Time.deltaTime);
			/*
			Vector2 size = Vector2.zero;
			Vector3 bound = GetComponent<MeshFilter> ().mesh.bounds.size;
			size.x = bound.x;
			size.y = bound.y;
			Ray ray = new Ray (transform.position, direction);
			RaycastHit rh;
			if (!Physics2D.Raycast () 
			{
				rb.MovePosition (currentPos + direction * speed * Time.deltaTime);
			} 
			else 
			{
				Debug.Log ("Cannot move: " + rh.collider.name);
			}
			*/
		} 
		else 
		{
			transform.Translate (direction * speed * Time.deltaTime, Space.World);
		}
	}

	public float Speed
	{
		get{return speed;}
		set{speed = value;}
	}
}
