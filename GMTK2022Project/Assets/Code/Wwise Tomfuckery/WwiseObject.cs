using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WwiseObject : MonoBehaviour
{

    [SerializeField] AK.Wwise.Event wwiseEvent;

    public void PostWwiseEvent(GameObject caller) {
        if (wwiseEvent.IsValid()) {
            Debug.Log("Played Wwise Event: " + wwiseEvent);
            wwiseEvent.Post(caller);
        }
        else {
            Debug.LogWarning("Warning: Missing Event for Wwise Obj: " + wwiseEvent);
        }
    }
}
