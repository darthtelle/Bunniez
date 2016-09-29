using UnityEngine;
using System.Collections;

public class PlayerMovement_CharacterController : MonoBehaviour 
{
	public float k_MaxSpeed = 5.0f;

	private CharacterController m_CharacterController;

	private void Awake()
	{
		m_CharacterController = gameObject.GetComponent<CharacterController>();
	}

	private void Update()
	{
		float horizontal = Input.GetAxis("Horizontal");
		m_CharacterController.SimpleMove(Vector3.right * horizontal * k_MaxSpeed);
	}
}
