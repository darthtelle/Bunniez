using UnityEngine;
using System.Collections;

public class PlayerMovement_Physics : MonoBehaviour
{
	public float k_MaxSpeed = 5.0f;
	public float k_MoveSpeed = 365.0f;

	private Rigidbody m_RigidBody;

	private bool m_Grounded;
	private bool m_Jump;

	private void Awake()
	{
		m_RigidBody = gameObject.GetComponent<Rigidbody>();
	}

	private void Update()
    {
	
	}

	private void FixedUpdate()
	{
		float horizontal = Input.GetAxis("Horizontal");
		if(horizontal * m_RigidBody.velocity.x < k_MaxSpeed)
		{
			m_RigidBody.AddForce(Vector3.right * horizontal * k_MoveSpeed);
		}

		if(Mathf.Abs(m_RigidBody.velocity.x) > k_MaxSpeed)
		{
			m_RigidBody.velocity = new Vector3(Mathf.Sign(m_RigidBody.velocity.x) * k_MaxSpeed, m_RigidBody.velocity.y, m_RigidBody.velocity.z);
		}
	}
}
