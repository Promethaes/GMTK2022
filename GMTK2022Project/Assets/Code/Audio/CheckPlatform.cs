using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlatform : MonoBehaviour
{
    [Header("Use Unity Audio")]
    [SerializeField] bool simulateWebGL = false;
    
    [HideInInspector] public bool isUsingWwise = true;
    bool currentStatus = true;

    void Start()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer || (simulateWebGL && Application.platform == RuntimePlatform.WindowsEditor))
            isUsingWwise = false;
        else
            isUsingWwise = true;
        currentStatus = isUsingWwise;
    }

    void Update()
    {
        if (currentStatus != isUsingWwise)
        {
            if (Application.platform == RuntimePlatform.WebGLPlayer || simulateWebGL)
                isUsingWwise = false;
            else
                isUsingWwise = true;
            currentStatus = isUsingWwise;
        }
    }
}
