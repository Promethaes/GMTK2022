using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
	[SerializeField]
	Health playerHealth = null;

	[SerializeField]
	[Tooltip("Important: put clips in order from lowest to highest (2-1 first, 6-5 last)")]
	AnimationClip[] healthChangeAnims = new AnimationClip[0];
	
	Animator m_animator;

	void Awake()
	{
		m_animator = GetComponent<Animator>();
	}
	
	public void UpdateHealthUI()
	{
		int desiredAnimIndex = Mathf.RoundToInt(playerHealth.GetHealth() - 2);

		if (desiredAnimIndex < 0 || desiredAnimIndex >= healthChangeAnims.Length)
		{
			return;
		}
		
		m_animator.Play(healthChangeAnims[desiredAnimIndex].name);
	}
}
