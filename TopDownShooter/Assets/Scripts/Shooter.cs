using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
	public Projectile projectile;
	public float distanceOffset = 1f;
	public float shootCooldown = 0.5f;
	private bool canShoot = true;
	private bool rTriggerReleased = true;
	private Vector2 shootDir;
	public float rJoystickSensitivity = 0.5f;

	public enum ShootingType
	{
		Forward,
		AimAndTrigger,
		AutoDirectional
	}
	public ShootingType shootingType;
	public ShootingInterface shootingScript;

	void Awake ()
	{
		//shootingScript = GetComponent<ShootingInterface> ();
		shootDir = (Vector2)transform.up;
		//shootingScript.Projectile = projectile;
		//shootingScript.DistanceOffset = distanceOffset;
	}

	void Update ()
	{
		shootingScript.Projectile = projectile;
		shootingScript.DistanceOffset = distanceOffset;
		Vector2 input = InputDirection;
		if (input != Vector2.zero) 
		{
			shootDir = input;
			transform.up = input;
		}

		if (canShoot) 
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
	}

	private void Shoot_AutoDirectional ()
	{
		if (InputDirection != Vector2.zero)
		{
			shootingScript.Shoot (shootDir, Projectile.Allegiance.Good);
			TriggerCooldown ();
		}
	}

	private void Shoot_Forward ()
	{
		if (Input.GetButtonDown ("Fire3"))
		{
			shootingScript.Shoot (shootDir, Projectile.Allegiance.Good);
			canShoot = false;
			TriggerCooldown ();
		}
	}

	private void Shoot_AimAndTrigger ()
	{
		float rTrigger = Input.GetAxisRaw ("RTrigger");
		if (rTriggerReleased && rTrigger == 1f)
		{
			shootingScript.Shoot (shootDir, Projectile.Allegiance.Good);
			canShoot = false;
			TriggerCooldown ();
		}

		if (rTriggerReleased && rTrigger == 1f || !rTriggerReleased && rTrigger != 1f) 
		{
			rTriggerReleased = !rTriggerReleased;
		}
	}

	private void TriggerCooldown ()
	{
		canShoot = false;
		Invoke ("CooldownOver", shootCooldown);
	}

	private void CooldownOver ()
	{
		canShoot = true;
	}

	public Vector2 InputDirection
	{
		get
		{ 
			Vector2 dir = new Vector2 (
				Input.GetAxisRaw (InputsNames.RIGHT_JOYSTICK_HORIZONTAL), 
				Input.GetAxisRaw (InputsNames.RIGHT_JOYSTICK_VERTICAL)
			);

			dir = dir.magnitude > rJoystickSensitivity ? dir.normalized : Vector2.zero;
			return dir;
		}
	}
}
