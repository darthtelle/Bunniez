using UnityEngine;
using System.Collections;

public class PlayerMovement_CharacterController : MonoBehaviour 
{
	private const float k_Gravity = 20.0f;
	public float k_MaxSpeed = 5.0f;
	public float k_JumpSpeed = 8.0f;

	[SerializeField]
	private GameObject m_BodyObject;

	private CharacterController m_CharacterController;
	private Vector3 m_MoveDirection;

	private void Awake()
	{
		m_CharacterController = gameObject.GetComponent<CharacterController>();
		m_MoveDirection = Vector3.zero;

		if(m_BodyObject == null)
		{
			Debug.LogError("ERROR: Body object is null.");
		}
	}

	private void Update()
	{
		float horizontal = Input.GetAxis("Horizontal");
		m_MoveDirection.x = horizontal * k_MaxSpeed;

		if(m_CharacterController.isGrounded)
		{
			if(Input.GetButtonDown("Jump"))
			{
				m_MoveDirection.y = k_JumpSpeed;
			}
		}

		m_MoveDirection.y -= k_Gravity * Time.deltaTime;
		m_CharacterController.Move(m_MoveDirection * Time.deltaTime);

		Flip();
	}

	private void Flip()
	{
		if(((m_MoveDirection.x > 0.0f) && (m_BodyObject.transform.localScale.x < 0.0f)) || ((m_MoveDirection.x < 0.0f) && (m_BodyObject.transform.localScale.x > 0.0f)))
		{
			Vector3 scale = m_BodyObject.transform.localScale;
			scale.x *= -1.0f;
			m_BodyObject.transform.localScale = scale;
		}
	}
}
