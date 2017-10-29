using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour 
{
	private float aggroDistance = 7f;
	private bool seeingAvatar;

	public delegate void AvatarDetectedHandler ();
	public event AvatarDetectedHandler AvatarDetected;

	public delegate void LostVisionHandler ();
	public event LostVisionHandler LostVision;

	public delegate void SeeingAvatarHandler ();
	public event SeeingAvatarHandler SeeingAvatar;

	void Update ()
	{
		bool avatarInRange = AvatarInRange ();
		bool hasVision = HasVision ();

		if (avatarInRange && hasVision)
		{
			if (!seeingAvatar)
			{
				seeingAvatar = true;
				OnAvatarDetected ();
			}
			OnSeeingAvatar ();
		}
		else if (seeingAvatar && (!avatarInRange || !hasVision))
		{
			seeingAvatar = false;
			OnLostVision ();
		}
	}

	void OnAvatarDetected ()
	{
		Debug.Log ("[" + name + "] detected the Avatar.");
		if (AvatarDetected != null)
		{
			AvatarDetected ();
		}
	}

	void OnLostVision ()
	{
		Debug.Log ("[" + name + "] lost vision with avatar.");
		if (LostVision != null)
		{
			LostVision ();
		}
	}

	void OnSeeingAvatar ()
	{
		if (SeeingAvatar != null)
		{
			SeeingAvatar ();
		}
	}

	public float AggroDistance
	{
		set{ aggroDistance = value; }
	}

	private bool AvatarInRange ()
	{
		return AvatarRespawner.Instance.Avatar != null 
			&& Vector2.Distance (VectorFunc.ConvertTo2DVec (AvatarRespawner.Instance.Avatar.transform.position), VectorFunc.ConvertTo2DVec (transform.position)) < aggroDistance;
	}

	private bool HasVision ()
	{
		if (AvatarRespawner.Instance.Avatar != null)
		{
			RaycastHit2D hit = Physics2D.Raycast (transform.position, AvatarRespawner.Instance.Avatar.transform.position - transform.position, aggroDistance, 1 << LayerMask.NameToLayer ("VisionBlocker"));
			if (hit.collider != null)
			{
				if (hit.collider.tag == "Player")
				{
					return true;
				}
			}
		}
		return false;
	}
}
