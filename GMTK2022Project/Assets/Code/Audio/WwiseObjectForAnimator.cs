using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WwiseObjectForAnimator : MonoBehaviour
{
    [SerializeField] AK.Wwise.Event wwiseEvent;

    void Start()
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
    }
}
