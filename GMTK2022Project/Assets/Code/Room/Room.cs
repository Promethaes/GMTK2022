using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
	[SerializeField]
	private EntryTrigger entryTrigger = null;

	[SerializeField]
	private List<GameObject> exitBlockers = new List<GameObject>();

	void Awake()
	{
		SetBlockersActive(false);
		
		entryTrigger.onEntryTriggered.AddListener(OnRoomEntered);
	}

	void OnRoomEntered()
	{
		SetBlockersActive(true);
	}

	public void SetBlockersActive(bool a_active)
	{
		foreach (var blocker in exitBlockers)
		{
			blocker.SetActive(a_active);
		}
	}
}
