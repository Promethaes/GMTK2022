using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookDirectionTracker : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;
    [SerializeField] Transform flippingObject;
	[SerializeField] SpriteRenderer playerSpriteRenderer;

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

        var pos = playerTransform.position + (newDirection * lookAheadDistance);
        transform.position = playerTransform.position + (newDirection * lookAheadDistance);
        var angle = Mathf.Atan2(newDirection.y, newDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        angle = Mathf.Abs(angle);

        float sign = 1.0f;
        sign = angle >= 90.0f ? -1.0f : 1.0f;
		var tempScale = flippingObject.localScale;
		tempScale.x = Mathf.Abs(tempScale.x);
		tempScale.y = Mathf.Abs(tempScale.y) * sign;
		tempScale.z = Mathf.Abs(tempScale.z);
        flippingObject.localScale = tempScale;
		if(playerSpriteRenderer)
			playerSpriteRenderer.flipX = angle >= 90.0f;
    }
}
