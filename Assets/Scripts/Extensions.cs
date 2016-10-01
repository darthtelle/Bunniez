using UnityEngine;
using System.Collections;

public static class GameObjectExtensions
{
	public static void SetParent(this GameObject thisObject, GameObject parentObject)
	{
		if(parentObject != null)
		{
			thisObject.transform.SetParent(parentObject.transform);
		}
		else
		{
			thisObject.transform.SetParent(null);
		}
	}
}
