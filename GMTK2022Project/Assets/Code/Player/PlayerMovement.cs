using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField]
	float moveSpeed = 4f;
	
	[Header("Dodge Roll")]
	[SerializeField]
	float rollSpeed = 8f;
	
	[SerializeField]
	float rollDuration = 0.4f;
	
	[SerializeField]
	float rollCooldown = 0.25f;

	Rigidbody2D m_rigidbody;

	bool m_isRolling = false;
	
	float m_lastTimeRollEnded = Mathf.NegativeInfinity;

	public bool IsRolling
	{
		get => m_isRolling;
		set => m_isRolling = value;
	}

	void Awake()
	{
		m_rigidbody = GetComponent<Rigidbody2D>();
	}
	
    void Update()
    {
	    if (m_isRolling)
	    {
		    return;
	    }
	    
	    Vector2 moveAxis = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
	    if (moveAxis.sqrMagnitude > 1f)
	    {
		    moveAxis = moveAxis.normalized;
	    }

	    m_rigidbody.velocity = moveAxis * moveSpeed;

	    if (Input.GetKeyDown(KeyCode.Space) && CanRoll())
	    {
		    StartCoroutine(RollRoutine(moveAxis));
	    }
    }

    IEnumerator RollRoutine(Vector2 moveAxis)
    {
	    m_isRolling = true;

	    m_rigidbody.velocity = moveAxis * rollSpeed;

	    yield return new WaitForSeconds(rollDuration);

	    m_lastTimeRollEnded = Time.time;
	    
		m_isRolling = false;
    }

    bool CanRoll()
    {
	    return !m_isRolling && Time.time > m_lastTimeRollEnded + rollCooldown;
    }
}
