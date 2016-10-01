using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	/*[SerializeField]
	private GameObject[] m_PlayerList;*/ // TODO: For the future want to have multiple players.

	[SerializeField]
	private GameObject m_Player;

	private Vector3 m_Offset;

	private void Start()
	{
		m_Offset = gameObject.transform.position - m_Player.transform.position;
	}

	private void LateUpdate()
	{
		gameObject.transform.position = m_Player.transform.position + m_Offset;
	}
}
