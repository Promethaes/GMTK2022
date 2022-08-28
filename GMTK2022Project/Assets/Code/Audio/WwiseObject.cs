using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WwiseObject : MonoBehaviour
{

    [SerializeField] AK.Wwise.Event wwiseEvent;
    [SerializeField] AudioClipRandomizer audioEvent;

    static CheckPlatform checkPlatform;

    void Start()
    {
        checkPlatform = FindObjectOfType<CheckPlatform>();
    }

    public void PostWwiseEvent() {
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
            //Debug.Log("Playing Unity Audio");
        }
    }
}
