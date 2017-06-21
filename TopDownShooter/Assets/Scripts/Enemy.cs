using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
	public string displayName = "UNNAMED";
	private HPScript hpScript;

	void Awake ()
	{
		hpScript = GetComponent<HPScript> ();
	}

	public HPScript HPScript
	{
		get{return hpScript;}
	}
}
