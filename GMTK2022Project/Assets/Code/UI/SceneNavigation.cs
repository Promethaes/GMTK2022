using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneNavigation : MonoBehaviour
{

    IEnumerator Wait(int index)
    {
        yield return new WaitForSeconds(0.5f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
    }
    public void Retry()
    {
        StartCoroutine(Wait(1));
    }
    public void MainMenu()
    {
        StartCoroutine(Wait(0));
    }
}
