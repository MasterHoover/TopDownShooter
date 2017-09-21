using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAvatar : MonoBehaviour 
{
	private Transform avatar;
	public float distance = 10f;

	void Start ()
	{
		FetchAvatar ();
	}

	void OnEnable ()
	{
		FetchAvatar ();
	}

	private void FetchAvatar ()
	{
		GameObject av_obj = GameObject.FindGameObjectWithTag ("Player");
		if (av_obj == null)
		{
			Debug.LogWarning (name + "[FollowAvatar/Start()]: No avatar was found in the scene. Disabling script.");
			enabled = false;
		}
		else
		{
			avatar = av_obj.transform;
		}
	}

	void LateUpdate ()
	{
		transform.position = avatar.position + Vector3.back * Mathf.Abs (distance);
	}
}
