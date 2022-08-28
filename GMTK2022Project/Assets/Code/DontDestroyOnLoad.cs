using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    bool exists = false;

    void Start()
    {
        if (!exists) {
            DontDestroyOnLoad(this.gameObject);
            exists = true;
        }
    }
}
