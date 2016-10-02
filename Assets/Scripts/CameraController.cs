using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	private const float k_DampTime = 0.2f;
	private const float k_ScreenEdgeBuffer = 4.0f;
	private const float k_MinSize = 6.5f;

	[SerializeField]
	private GameObject[] m_PlayerList;

	private Camera m_Camera;

	private Vector3 m_AveragePosition;
	private Vector3 m_MoveVelocity;
	private float m_ZoomSpeed;

	private void Awake()
	{
		m_Camera = gameObject.GetComponentInChildren<Camera>();
	}

		private void FixedUpdate()
	{
		Move();
		Zoom();
	}

	private void Move()
	{
		m_AveragePosition = FindAveragePosition();
		gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, m_AveragePosition, ref m_MoveVelocity, k_DampTime);
	}

	private void Zoom()
	{
		float size = FindRequiredSize();
		m_Camera.orthographicSize = Mathf.SmoothDamp(m_Camera.orthographicSize, size, ref m_ZoomSpeed, k_DampTime);
	}

	private Vector3 FindAveragePosition()
	{
		Vector3 averagePosition = new Vector3();
		int playerCount = 0;

		for(int playerIndex = 0; playerIndex < m_PlayerList.Length; playerIndex++)
		{
			// Check whether the target is active.
			if(m_PlayerList[playerIndex].activeSelf == false)
				continue;

			// Add to the average position.
			averagePosition += m_PlayerList[playerIndex].transform.position;

			// Incremenent the number of players.
			playerCount++;
		}

		if(playerCount > 0)
		{
			// Divide the sum of positions by the number of players to find the average position.
			averagePosition /= playerCount;
		}

		averagePosition.z = gameObject.transform.position.z;

		return averagePosition;
	}

	private float FindRequiredSize()
	{
		// Find the position the camera rig is moving towards in its local space.
		Vector3 localPosition = gameObject.transform.InverseTransformPoint(m_AveragePosition);

		float size = 0.0f;

		for(int playerIndex = 0; playerIndex < m_PlayerList.Length; playerIndex++)
		{
			// Check whether the target is active.
			if(m_PlayerList[playerIndex].activeSelf == false)
				continue;

			Vector3 playerLocalPosition = gameObject.transform.InverseTransformPoint(m_PlayerList[playerIndex].transform.position);

			// Find the position of the player from the local position of the camera.
			Vector3 positionToTarget = playerLocalPosition - localPosition;

			// Find the maximum size based on the y position.
			size = Mathf.Max(size, Mathf.Abs(positionToTarget.y));

			// Find the maximum size based on the x position.
			size = Mathf.Max(size, Mathf.Abs(positionToTarget.x) / m_Camera.aspect);
		}

		// Add the edge buffer to the camera size.
		size += k_ScreenEdgeBuffer;

		// Make sure the camera's size isn't below the minimum size.
		size = Mathf.Max(size, k_MinSize);

		return size;
	}
}
