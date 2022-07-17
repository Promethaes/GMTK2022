using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTracker : MonoBehaviour
{
	public static float currentTime;

	public static bool isPaused;

	void Start()
	{
		currentTime = 0f;
		isPaused    = false;
	}
	
    void Update()
    {
	    if (isPaused)
	    {
		    return;
	    }

	    currentTime += Time.deltaTime;
    }
}
