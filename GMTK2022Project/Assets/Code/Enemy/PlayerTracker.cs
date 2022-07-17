using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTracker : MonoBehaviour
{
	public UnityEvent onTargetSpotted = null;

	[SerializeField]
	float detectionRange = 10f;

	static Transform s_playerTransform;

	bool m_isTracking = false;

	float sqrDetectionRange;

	public bool IsTracking
	{
		get => m_isTracking;
	}

	public Vector3 PlayerPosition
	{
		get => s_playerTransform.position;
	}

	public Vector3 DirectionToPlayer
	{
		get => Vector3.Normalize(s_playerTransform.position - transform.position);
	}

	void Awake()
	{
		if (!s_playerTransform)
		{
			s_playerTransform = FindObjectOfType<PlayerMovement>().transform;
		}

		sqrDetectionRange = detectionRange * detectionRange;
	}

	void Update()
	{
		if (m_isTracking)
		{
			return;
		}

		if ((transform.position - s_playerTransform.position).sqrMagnitude < sqrDetectionRange)
		{
			m_isTracking = true;
			onTargetSpotted?.Invoke();
		}
	}
}
