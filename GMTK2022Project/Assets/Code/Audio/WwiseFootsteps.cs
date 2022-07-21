using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WwiseFootsteps : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] AK.Wwise.Event wwiseEvent;
    //[SerializeField] AudioRandomizerContainer audioContainer;

    [Header("Settings")]
    [SerializeField] float footstepTime = 0.35f;
    [SerializeField] bool m_isPlayer = false;

    PlayerMovement playerMovement = null;
    EnemyMovement enemyMovement = null;
    bool isCoroutineRunning = false;

    void Start()
    {
        if (m_isPlayer)
            playerMovement = gameObject.GetComponent<PlayerMovement>();
        else
            enemyMovement = gameObject.GetComponent<EnemyMovement>();
    }

    void Update()
    {
        if ((playerMovement != null && playerMovement.IsMoving) ^ (enemyMovement != null && enemyMovement.IsMoving) && !isCoroutineRunning)
            StartCoroutine(FootstepRoutine());
    }

    IEnumerator FootstepRoutine()
    {
        isCoroutineRunning = true;
        if (wwiseEvent.IsValid())
        {
            //Debug.Log("Played Wwise Event: " + wwiseEvent);
            wwiseEvent.Post(Camera.main.gameObject);
        }
        else
        {
            Debug.LogWarning("Warning: Missing Event for Wwise Obj: " + wwiseEvent);
        }

        yield return new WaitForSeconds(footstepTime);

        //Debug.Log("Stopped Wwise Event: " + wwiseEvent);
        isCoroutineRunning = false;
    }
}
