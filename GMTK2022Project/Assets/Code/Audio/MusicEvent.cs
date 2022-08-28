using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MusicEvent : MonoBehaviour
{
    [SerializeField] UnityEvent onStart;
    [SerializeField] UnityEvent onStop;

    void Start()
    {
        onStart?.Invoke();
    }
    void OnDestroy()
    {
        onStop?.Invoke();
    }
}
