using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DiedEventArgs : EventArgs 
{
	private MonoBehaviour source;

	public DiedEventArgs (MonoBehaviour source)
	{
		this.source = source;
	}

	public MonoBehaviour Source
	{
		get{return source;}
	}
}
