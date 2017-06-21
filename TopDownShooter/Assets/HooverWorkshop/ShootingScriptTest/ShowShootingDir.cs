using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowShootingDir : MonoBehaviour 
{
	public Shooter shootingScript;
	private LineRenderer rend;
	public float lineDist = 5f;
	public Color color;

	void Awake ()
	{
		if (shootingScript == null) 
		{
			Debug.LogWarning ("ShowShootingDir[" + name + "]/Awake () : There is no shootingScript assigned. Disabling object.");
			enabled = false;
		} 
		else 
		{
			rend = GetComponent<LineRenderer> ();
		}
	}

	void Update ()
	{
		Vector3 shootingDir = (Vector3) shootingScript.InputDirection.normalized;
		float offset = shootingScript.distanceOffset;
		Vector3 pos = shootingScript.transform.position;

		Debug.Log ("[" + shootingScript.name + "] dir : " + shootingDir);
		rend.SetPositions (new Vector3[] {pos + shootingDir * offset, pos + shootingDir * offset * lineDist});
	}
}
