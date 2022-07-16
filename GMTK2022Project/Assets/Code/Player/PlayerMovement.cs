using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField]
	float moveSpeed = 4f;
	
	[Header("Dodge Roll")]
	[SerializeField]
	float rollSpeed = 10f;
	
	[SerializeField]
	float rollDuration = 1f;
	
	[SerializeField]
	float rollCooldown = 0.5f;

	Rigidbody2D m_rigidbody;

	void Awake()
	{
		m_rigidbody = GetComponent<Rigidbody2D>();
	}
	
    void Update()
    {
	    Vector2 moveAxis = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
	    if (moveAxis.sqrMagnitude > 1f)
	    {
		    moveAxis = moveAxis.normalized;
	    }

	    m_rigidbody.velocity = moveAxis * moveSpeed;

	    if (Input.GetKeyDown(KeyCode.Space))
	    {
		    
	    }
    }
}
