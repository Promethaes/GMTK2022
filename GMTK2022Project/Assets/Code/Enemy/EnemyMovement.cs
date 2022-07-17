using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    float chaseSpeed = 2.5f;

    [SerializeField]
    float wanderSpeed = 1.5f;

    [SerializeField]
    float stoppingDistance = 1f;

    protected PlayerTracker m_playerTracker;

    protected NavMeshAgent m_agent;
    protected NavMeshPath  m_navPath;

    protected Animator       m_animator;
    protected SpriteRenderer m_renderer;

    float m_randomDestinationCooldown = 6f;
    float m_randomDestinationTimer;

    protected virtual void Awake()
    {
        m_playerTracker = GetComponent<PlayerTracker>();
        m_agent         = GetComponent<NavMeshAgent>();
        m_animator      = GetComponent<Animator>();
        m_renderer      = GetComponent<SpriteRenderer>();

        m_agent.updateRotation = false;
        m_agent.updateUpAxis = false;

        m_randomDestinationTimer = Random.Range(m_randomDestinationCooldown * 0.5f, m_randomDestinationCooldown);

        m_navPath = new NavMeshPath();

        m_playerTracker.onTargetSpotted += EnemySpotted;
    }

    protected virtual void Update()
    {
	    //TODO: might want these later? Commenting out for now
        //if (playerIsDead)
        //{
        //    StopInstantly();
        //    return;
        //}

        //if (isAttacking)
        //{
        //    m_renderer.flipX = m_playerTracker.PlayerPosition.x > transform.position.x;

        //    StopInstantly();
        //    return;
        //}

        if (m_agent.velocity.x > 0.1f)
        {
            m_renderer.flipX = true;
        }
        else if (m_agent.velocity.x < -0.1f)
        {
            m_renderer.flipX = false;
        }

        if (m_playerTracker.IsTracking)
        {
            TrackingUpdate();
        }
        else
        {
	        WanderUpdate();
        }
    }

    protected void StopInstantly()
    {
        if (!m_agent)
        {
            return;
        }
        m_agent.ResetPath();
        m_agent.acceleration = 1000f;
        m_agent.speed        = 0f;
    }

    bool IsPathValid(Vector3 a_targetPosition)
    {
        m_agent.CalculatePath(a_targetPosition, m_navPath);

        if (m_navPath.status == NavMeshPathStatus.PathComplete)
        {
            return true;
        }

        return false;
    }

    void EnemySpotted()
    {
	    StopInstantly();
    }

    void TrackingUpdate()
    {
	    if (m_agent.velocity.sqrMagnitude < 0.01f)
	    {
		    //m_animator.Play(idleAnim.name);

		    m_renderer.flipX = m_playerTracker.PlayerPosition.x > transform.position.x;
	    }
	    else
	    {
		    //m_animator.Play(chaseAnim.name);
	    }

	    m_agent.stoppingDistance = stoppingDistance;

	    Vector3 playerPosition = m_playerTracker.PlayerPosition;

	    const float sampleDistance = 10f;
	    //find nearest point on nav mesh from target's current position
	    if (NavMesh.SamplePosition(playerPosition, out var navHit, sampleDistance, m_agent.areaMask))
	    {
		    playerPosition = navHit.position;
	    }

	    //only use new destination if it's reachable
	    if (IsPathValid(playerPosition))
	    {
		    m_agent.SetPath(m_navPath);
	    }
	    m_agent.speed = chaseSpeed;
    }

    void WanderUpdate()
    {
	    m_agent.speed = wanderSpeed;

	    if (m_randomDestinationTimer >= m_randomDestinationCooldown)
	    {
		    m_randomDestinationTimer = 0f;

		    const float maxRange = 3f;
		    Vector3 randomPosition = new Vector3(
			    Random.Range(-maxRange, maxRange),
			    Random.Range(-maxRange, maxRange),
			    0f);

		    randomPosition += transform.position;

		    if (NavMesh.SamplePosition(randomPosition, out _, 100f, NavMesh.AllAreas))
		    {
			    m_agent.SetDestination(randomPosition);
		    }
	    }

	    m_randomDestinationTimer += Time.deltaTime;
    }
}
