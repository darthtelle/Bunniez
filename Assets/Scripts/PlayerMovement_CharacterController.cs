using UnityEngine;
using System.Collections;

public class PlayerMovement_CharacterController : MonoBehaviour 
{
 	public bool d_ControlJump = false;

	public float k_MaxSpeed = 5.0f;

	private CharacterController m_CharacterController;
	private Vector3 m_MoveDirection;

	private void Awake()
	{
		m_CharacterController = gameObject.GetComponent<CharacterController>();
		m_MoveDirection = Vector3.zero;
	}

	private void Update()
	{
		float horizontal = Input.GetAxis("Horizontal");

		if(d_ControlJump)
		{
			m_MoveDirection.x = horizontal * k_MaxSpeed;
		}

		if(m_CharacterController.isGrounded)
		{
			if(d_ControlJump == false)
			{
				m_MoveDirection = new Vector3(horizontal, 0.0f, 0.0f);
				m_MoveDirection = gameObject.transform.TransformDirection(m_MoveDirection);
				m_MoveDirection *= k_MaxSpeed;
			}

			if(Input.GetButtonDown("Jump"))
			{
				m_MoveDirection.y = 8.0f;
			}
		}

		m_MoveDirection.y -= 20.0f * Time.deltaTime;
		m_CharacterController.Move(m_MoveDirection * Time.deltaTime);

		//m_CharacterController.SimpleMove(Vector3.right * horizontal * k_MaxSpeed);
	}
}
