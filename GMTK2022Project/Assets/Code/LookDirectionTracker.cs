using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookDirectionTracker : MonoBehaviour
{
	[SerializeField]
	private Transform playerTransform;

	[SerializeField]
	private float lookAheadDistance = 3f;

	private Camera m_mainCamera;

	void Awake()
	{
		m_mainCamera = Camera.main;
	}
	
	void Update()
    {
	    Vector3 mousePos = m_mainCamera.ScreenToWorldPoint(Input.mousePosition);
	    mousePos.z = 0f;

	    Vector3 newDirection = Vector3.Normalize(mousePos - playerTransform.position);

	    transform.position = playerTransform.position + (newDirection * lookAheadDistance);
    }
}
