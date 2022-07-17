using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EntryTrigger : MonoBehaviour
{
	public UnityEvent onEntryTriggered = new UnityEvent();

	void OnTriggerEnter2D(Collider2D a_other)
	{
		if (!a_other.attachedRigidbody.TryGetComponent<PlayerMovement>(out _))
		{
			return;
		}

		onEntryTriggered?.Invoke();

		gameObject.SetActive(false);
	}
}
