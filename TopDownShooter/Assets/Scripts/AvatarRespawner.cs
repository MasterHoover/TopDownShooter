using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarRespawner : MonoBehaviour 
{
	public GameObject avatarPrefab;
	private GameObject a;
	private Vector3 startPos;
	private Quaternion startRot;
	private static AvatarRespawner instance;

	void Awake ()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy (gameObject);
		}
	}

	void Start ()
	{
		a = GameObject.FindGameObjectWithTag ("Player");
		if (a != null)
		{
			startPos = a.transform.position;
			startRot = a.transform.rotation;
		} 
		else
		{
			Debug.LogWarning ("[" + name + "]: Avatar was not found in scene. Disabling script.");
			enabled = false;
		}
	}

	void Update ()
	{
		if (Input.GetButtonDown ("Start"))
		{
			RespawnAvatarIfDead ();
		}
	}
		
	private void RespawnAvatarIfDead ()
	{
		if (a == null)
		{
			a = Instantiate<GameObject> (avatarPrefab, startPos, startRot); 
		}
	}

	public GameObject Avatar
	{
		get{ return a; }
	}

	public static AvatarRespawner Instance
	{
		get{ return instance; }
	}
}
