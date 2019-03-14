using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempEnemyGen : MonoBehaviour
{
    public GameObject prefab;
    private Queue<GameObject> tempEnemyPool = new Queue<GameObject>();

    void Start()
    {
        InstantiatePool();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiatePool()
    {
        for (int i = 0; i < 5;i++)
        {
            var enemy = Instantiate(prefab);
            enemy.SetActive(false);
            tempEnemyPool.Enqueue(enemy);
        }
    }

    GameObject GetAEnemy()
    {
        var enemy = tempEnemyPool.Dequeue();
        enemy.SetActive(true);
        return enemy;
    }
}
