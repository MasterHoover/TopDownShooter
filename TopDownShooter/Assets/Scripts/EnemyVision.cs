using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour 
{
	private float aggroDistance = 7f;
	private bool sawAvatar;

	public delegate void AvatarDetectedHandler ();
	public event AvatarDetectedHandler AvatarDetected;

	public delegate void LostVisionHandler ();
	public event LostVisionHandler LostVision;

	void Update ()
	{
		bool avatarInRange = AvatarInRange ();
		bool seeingAvatar = SeeingAvatar ();

		if (!sawAvatar && avatarInRange && seeingAvatar)
		{
			sawAvatar = true;
			OnAvatarDetected ();
		}
		else if (sawAvatar && (!avatarInRange || !seeingAvatar))
		{
			sawAvatar = false;
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

	public float AggroDistance
	{
		set{ aggroDistance = value; }
	}

	private bool AvatarInRange ()
	{
		return AvatarRespawner.Instance.Avatar != null 
			&& Vector2.Distance (VectorFunc.ConvertTo2DVec (AvatarRespawner.Instance.Avatar.transform.position), VectorFunc.ConvertTo2DVec (transform.position)) < aggroDistance;
	}

	private bool SeeingAvatar ()
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
