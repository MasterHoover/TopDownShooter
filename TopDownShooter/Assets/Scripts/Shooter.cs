using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
	public Projectile projectile;
	public float shootCooldown = 0.5f;
	public float bulletSpeed = 15f;
	public AimingType aimingType;

	public ShootingType shootingType;
	public float distanceOffset = 1f;
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

	public enum AimingType
	{
		Deg360,
		Dir4,
		Dir8
	}


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
			if (aimingType == AimingType.Dir4)
			{
				float angleInRad = Mathf.Atan2 (input.y, input.x);
				float angleInDeg = angleInRad * Mathf.Rad2Deg;
				if (angleInDeg <= -135f)
				{
					// W
					input = Vector2.left;
				}
				else if (angleInDeg <= -45f)
				{
					// S
					input = Vector2.down;
				}
				else if (angleInDeg <= 45f)
				{
					// E
					input = Vector2.right;
				}
				else if (angleInDeg <= 135f)
				{
					// N
					input = Vector2.up;
				}
				else
				{
					// W
					input = Vector2.left;
				}
			} 
			else if (aimingType == AimingType.Dir8)
			{
				float angleInRad = Mathf.Atan2 (input.y, input.x);
				float angleInDeg = angleInRad * Mathf.Rad2Deg;
				if (angleInDeg <= -157.5f)
				{
					// W
					input = Vector2.left;
				}
				else if (angleInDeg <= -112.5f)
				{
					// SW
					float sqrt = Mathf.Sqrt (0.5f);
					input = new Vector2 (-sqrt, -sqrt);
				}
				else if (angleInDeg <= -67.5f)
				{
					//S
					input = Vector2.down;
				}
				else if (angleInDeg <= -22.5f)
				{
					// SE
					float sqrt = Mathf.Sqrt (0.5f);
					input = new Vector2 (sqrt, -sqrt); 
				}
				else if (angleInDeg <= 22.5f)
				{
					// E
					input = Vector2.right;
				}
				else if (angleInDeg <= 67.5f)
				{
					//NE
					float sqrt = Mathf.Sqrt (0.5f);
					input = new Vector2 (sqrt, sqrt);
				}
				else if (angleInDeg <= 112.5f)
				{
					//N
					input = Vector2.up;
				}
				else if (angleInDeg <= 157.5)
				{
					// NW
					float sqrt = Mathf.Sqrt (0.5f);
					input = new Vector2 (-sqrt, sqrt);
				}
				else
				{
					//W
					input = Vector2.left;
				}
			}
			Debug.Log ("input: " + input + "\t shootDir: " + shootDir);
			shootDir = input;
			transform.rotation = Quaternion.LookRotation (Vector3.forward, input);
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
			shootingScript.Shoot (shootDir, bulletSpeed, Projectile.Allegiance.Good);
			TriggerCooldown ();
		}
	}

	private void Shoot_Forward ()
	{
		if (Input.GetButtonDown ("Fire3"))
		{
			shootingScript.Shoot (shootDir, bulletSpeed, Projectile.Allegiance.Good);
			canShoot = false;
			TriggerCooldown ();
		}
	}

	private void Shoot_AimAndTrigger ()
	{
		float rTrigger = Input.GetAxisRaw ("RTrigger");
		if (rTriggerReleased && rTrigger == 1f)
		{
			shootingScript.Shoot (shootDir, bulletSpeed, Projectile.Allegiance.Good);
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
