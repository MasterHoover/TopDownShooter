using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HPScript))]
public class HPScriptEditor : Editor 
{
	public override void OnInspectorGUI ()
	{
		DrawDefaultInspector ();
		HPScript script = (HPScript)target;
	}
}
