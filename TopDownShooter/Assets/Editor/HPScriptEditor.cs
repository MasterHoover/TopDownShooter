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

		if (GUILayout.Button ("Damage")) 
		{
			if (Application.isPlaying) 
			{
				if (script.dmgSource != null)
				{
					script.hp -= script.dmgSource.damage;
				}
				else
				{
					Debug.LogWarning (name + " has no damage source reference.");
				}
			} 
			else 
			{
				Debug.LogWarning ("Damage: Use in Play mode!");
			}
		}
	}
}
