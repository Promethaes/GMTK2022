using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WwiseFootsteps : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] AK.Wwise.Event wwiseEvent;
    [SerializeField] AudioClipRandomizer audioEvent;

    [Header("Settings")]
    [SerializeField] float footstepTime = 0.35f;
    [SerializeField] bool m_isPlayer = false;

    PlayerMovement playerMovement = null;
    EnemyMovement enemyMovement = null;
    bool isCoroutineRunning = false;
    static CheckPlatform checkPlatform;

    void Start()
    {
        checkPlatform = FindObjectOfType<CheckPlatform>();

        if (m_isPlayer)
            playerMovement = FindObjectOfType<PlayerMovement>();
        else
            enemyMovement = gameObject.GetComponentInParent<EnemyMovement>();
    }

    void Update()
    {
        if ((playerMovement != null && playerMovement.IsMoving) ^ (enemyMovement != null && enemyMovement.IsMoving) && !isCoroutineRunning)
            StartCoroutine(FootstepRoutine());
    }

    IEnumerator FootstepRoutine()
    {
        isCoroutineRunning = true;
        if (checkPlatform.isUsingWwise)
        {
            if (wwiseEvent.IsValid())
            {
                //Debug.Log("Played Wwise Event: " + wwiseEvent);
                wwiseEvent.Post(Camera.main.gameObject);
            }
            else
            {
                Debug.LogWarning("Warning: Missing Event for Wwise Obj: " + wwiseEvent);
            }
        }
        else
        {
            if (audioEvent != null)
                audioEvent.PlaySFX();
        }

        yield return new WaitForSeconds(footstepTime);

        //Debug.Log("Stopped Wwise Event: " + wwiseEvent);
        isCoroutineRunning = false;
    }
}
