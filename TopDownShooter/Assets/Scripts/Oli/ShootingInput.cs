using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (ShootingScript))]
public class ShootingInput : MonoBehaviour
{
	public enum ShootingType
	{
		Forward,
		AimAndTrigger,
		AutoDirectional
	}
	public ShootingType shootingType;
	private ShootingScript shootingScript;

	void Awake ()
	{
		shootingScript = GetComponent<ShootingScript> ();
	}

	void Update ()
	{
		if (shootingType == ShootingType.Forward)
		{
			Shoot_Forward ();
		}
		else if (shootingType == ShootingType.AutoDirectional)
		{
			Shoot_AutoDirectional ();
		}
		else if (shootingType == ShootingType.AimAndTrigger)
		{
			Shoot_AimAndTrigger ();
		}
	}

	private void Shoot_AutoDirectional ()
	{
		Vector2 dir = InputDirection;
		if (dir != Vector2.zero)
		{
			shootingScript.Shoot (dir, Projectile.Allegiance.Good);
		}
	}

	private void Shoot_Forward ()
	{
		Vector2 dir = transform.up;
		if (Input.GetButtonDown ("Fire1"))
		{
			shootingScript.Shoot (dir, Projectile.Allegiance.Good);
		}
	}

	private void Shoot_AimAndTrigger ()
	{
		if (Input.GetAxisRaw ("RTrigger") == 1f)
		{
			Vector2 dir = InputDirection;
			if (dir != Vector2.zero)
			{
				shootingScript.Shoot (dir, Projectile.Allegiance.Good);
			}
		}
	}

	public Vector2 InputDirection
	{
		get
		{ 
			return new Vector2 (
				Input.GetAxisRaw (InputsNames.RIGHT_JOYSTICK_HORIZONTAL), 
				Input.GetAxisRaw (InputsNames.RIGHT_JOYSTICK_VERTICAL)
			);
		}
	}
}
