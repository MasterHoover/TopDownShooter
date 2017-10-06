using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleLog : MonoBehaviour 
{
	private static BattleLog instance;

	void Awake ()
	{
		if (instance == null) 
		{
			DontDestroyOnLoad (gameObject);
			instance = this;
		} 
		else 
		{
			Destroy (this);
		}
	}

	void Start ()
	{
		SubscribeToScript ();
	}
		
	private void SubscribeToScript ()
	{
		HPScript[] hpScripts = GameObject.FindObjectsOfType<HPScript> ();
		foreach (HPScript s in hpScripts) 
		{
			Debug.Log (name + " subscribed to " + s.name);
		}
	}

	protected void OnInstanceKilled (object source, System.EventArgs e)
	{
		string message = "[" + ((MonoBehaviour)source).name + "] was killed";
		if (e != System.EventArgs.Empty && e != null)
		{
			message += " by " + ((DiedEventArgs)e).Source.name + "]";
		}
		Debug.Log (message);
	}

	public static BattleLog Instance
	{
		get{return instance;}
	}
}
