using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
	public UnityEvent onRollStarted = null;
	
	public UnityEvent onRollEnded = null;

	[Header("General")]
	[SerializeField]
	float moveSpeed = 4f;
	
	[Header("Dodge Roll")]
	[SerializeField]
	float rollSpeed = 8f;
	
	[SerializeField]
	float rollDuration = 0.4f;
	
	[SerializeField]
	float rollCooldown = 0.7f;
	
	[Header("Particles")]
	[SerializeField]
	ParticleSystem walkEffect = null;

	[Header("Animator")]
	[SerializeField] Animator animator = null;

	Rigidbody2D m_rigidbody;

	bool m_isRolling = false;
	bool m_isMoving = false;
	
	float m_lastTimeRollEnded = Mathf.NegativeInfinity;

	public bool IsRolling
	{
		get => m_isRolling;
		set => m_isRolling = value;
	}
	public bool IsMoving
	{
		get => m_isMoving;
		set => m_isMoving = value;
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
	    
	    if (Mathf.Approximately(moveAxis.sqrMagnitude, 0f))
	    {
		    walkEffect.Stop();
			m_isMoving = false;
	    }
		else if(walkEffect.isStopped)
	    {
			walkEffect.Play();
			m_isMoving = true;
		}

		if (moveAxis.sqrMagnitude > 1f)
	    {
		    moveAxis = moveAxis.normalized;
	    }

	    m_rigidbody.velocity = moveAxis * moveSpeed;
		animator.SetFloat("plr_speed", m_rigidbody.velocity.magnitude);

	    if (Input.GetButton("Roll") && CanRoll())
	    {
		    StartCoroutine(RollRoutine(moveAxis));
	    }
    }

    IEnumerator RollRoutine(Vector2 moveAxis)
    {
	    m_isRolling = true;
		animator.SetBool("is_rolling", true);

		onRollStarted?.Invoke();

		if (Mathf.Approximately(moveAxis.sqrMagnitude, 0f))
	    {
		    moveAxis = Vector2.right;
	    }

		m_rigidbody.velocity = moveAxis.normalized * rollSpeed;

	    yield return new WaitForSeconds(rollDuration);

	    m_lastTimeRollEnded = Time.time;
	    
		m_isRolling = false;
		animator.SetBool("is_rolling", false);

		onRollEnded?.Invoke();
    }

    bool CanRoll()
    {
	    return !m_isRolling && Time.time > m_lastTimeRollEnded + rollCooldown;
    }
}
