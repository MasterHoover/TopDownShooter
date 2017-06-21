using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
	private MovingInterface movingInterface;
	public float speed;

	void Awake ()
	{
		movingInterface = GetComponent<MovingInterface> ();
	}

	void Update ()
	{
		movingInterface.Speed = speed;
		Move ();
	}

	private void Move ()
	{
		Vector2 dir = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		movingInterface.Move (dir);
	}
}
