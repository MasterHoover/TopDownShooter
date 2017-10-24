using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorFunc : MonoBehaviour 
{
	public static Vector2 ConvertTo2DVec (Vector3 v)
	{
		return new Vector2 (v.x, v.y);
	}
}
