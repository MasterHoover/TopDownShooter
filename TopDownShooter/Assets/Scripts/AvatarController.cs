using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarController : MonoBehaviour
{
	private MovementInterface moveScript;
	public float speed;

	public enum ControlType
	{
		Deg360,
		Dir4,
		Dir8
	}

	public ControlType controlType;

	void Update ()
	{
		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");

		if (x != 0f || y != 0f)
		{
			switch (controlType)
			{
			case ControlType.Deg360:
				Deg360Movement (x, y);
				break;
			case ControlType.Dir4:
				Dir4Movement (x, y);
				break;
			case ControlType.Dir8:
				Dir8Movement (x, y);
				break;
			default:
				Debug.LogWarning ("AvatarController/Update (): the controlType is unknown: " + controlType);
				break;
			}
		}
	}

	private void Deg360Movement (float x, float y)
	{
		moveScript.Move (new Vector2 (x, y), speed);
	}

	private void Dir4Movement (float x, float y)
	{
		float angleInRad = Mathf.Atan2 (y, x);
		float angleInDeg = angleInRad * Mathf.Rad2Deg;
		Debug.Log (angleInDeg);
		if (angleInDeg <= -135f)
		{
			// W
			moveScript.Move (Vector2.left, speed);
		}
		else if (angleInDeg <= -45f)
		{
			// S
			moveScript.Move (Vector2.down, speed);
		}
		else if (angleInDeg <= 45f)
		{
			// E
			moveScript.Move (Vector2.right, speed);
		}
		else if (angleInDeg <= 135f)
		{
			// N
			moveScript.Move (Vector2.up, speed);
		}
		else
		{
			// W
			moveScript.Move (Vector2.left, speed);
		}
	}

	private void Dir8Movement (float x, float y)
	{
		float angleInRad = Mathf.Atan2 (y, x);
		float angleInDeg = angleInRad * Mathf.Rad2Deg;
		if (angleInDeg <= -157.5f)
		{
			// W
			moveScript.Move (Vector2.left, speed);
		}
		else if (angleInDeg <= -112.5f)
		{
			// SW
			float sqrt = Mathf.Sqrt (0.5f);
			moveScript.Move (new Vector2 (-sqrt, -sqrt), speed);
		}
		else if (angleInDeg <= -67.5f)
		{
			//S
			moveScript.Move (Vector2.down, speed);
		}
		else if (angleInDeg <= -22.5f)
		{
			// SE
			float sqrt = Mathf.Sqrt (0.5f);
			moveScript.Move (new Vector2 (sqrt, -sqrt), speed);
		}
		else if (angleInDeg <= 22.5f)
		{
			// E
			moveScript.Move (Vector2.right, speed);
		}
		else if (angleInDeg <= 67.5f)
		{
			//NE
			float sqrt = Mathf.Sqrt (0.5f);
			moveScript.Move (new Vector2 (sqrt, sqrt), speed);
		}
		else if (angleInDeg <= 112.5f)
		{
			//N
			moveScript.Move (Vector2.up, speed);
		}
		else if (angleInDeg <= 157.5)
		{
			// NW
			float sqrt = Mathf.Sqrt (0.5f);
			moveScript.Move (new Vector2 (-sqrt, sqrt), speed);
		}
		else
		{
			//W
			moveScript.Move (Vector2.left, speed);
		}
	}
	void Awake ()
	{
		moveScript = GetComponent<MovementInterface> ();
	}
}
