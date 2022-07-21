using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WwiseObject : MonoBehaviour
{

    [SerializeField] AK.Wwise.Event wwiseEvent;

    public void PostWwiseEvent() {
        if (wwiseEvent.IsValid()) {
            //Debug.Log("Played Wwise Event: " + wwiseEvent);
            wwiseEvent.Post(Camera.main.gameObject);
        }
        else {
            Debug.LogWarning("Warning: Missing Event for Wwise Obj: " + wwiseEvent);
        }
    }
}
