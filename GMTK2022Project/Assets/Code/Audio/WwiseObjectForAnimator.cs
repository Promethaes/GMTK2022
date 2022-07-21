using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WwiseObjectForAnimator : MonoBehaviour
{
    [SerializeField] AK.Wwise.Event wwiseEvent;
    [SerializeField] float footstepTime = 1.0f;

    static uint[] playingIds = new uint[50];

    void OnEnable()
    {
        FootstepRoutine();
    }

    IEnumerator FootstepRoutine()
    {
        if (wwiseEvent.IsValid())
        {
            Debug.Log("Played Wwise Event: " + wwiseEvent);
            wwiseEvent.Post(Camera.main.gameObject);
        }
        else
        {
            Debug.LogWarning("Warning: Missing Event for Wwise Obj: " + wwiseEvent);
        }

        yield return new WaitForSeconds(footstepTime);

        Debug.Log("Stopped Wwise Event: " + wwiseEvent);
        gameObject.GetComponent<WwiseObjectForAnimator>().enabled = false;
    }
}
