using UnityEngine;
using System.Collections;

public class UIBringToFront : MonoBehaviour 
{
	private void OnEnable()
	{
		gameObject.transform.SetAsLastSibling();
	}
}
