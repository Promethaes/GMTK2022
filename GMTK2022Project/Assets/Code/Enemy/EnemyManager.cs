using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> enemies;
    public UnityEvent OnAllDead;

    private void Update()
    {
        int deadCount = 0;
        foreach (var item in enemies)
        {
            deadCount += (item.activeSelf) ? 0 : 1;
        }
        if (deadCount == enemies.Count)
        {
            OnAllDead.Invoke();
            gameObject.SetActive(false);
        }
    }
    public void SpawnEnemies()
    {
        enemies.ForEach(x => x.SetActive(true));
    }
}
