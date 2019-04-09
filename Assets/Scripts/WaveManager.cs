using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private int enemiesToSpawn;
    private bool canSpawn = true;
    public GameObject[] spawnPoints;
    public int currentWave = 5;
    private int b;

    private IEnumerator calculateEnemies(int wave)
    {

        for (int a = 0; a <= wave; a++)
        {
            wave *= 3;
            if (a > 5)
            {
                b = a - 5;
                spawnPoints[b].GetComponent<enemySpawner>().StartCoroutine("spawnEnemy");
            }

            else if (a <= 5)
            {
                b = a;
                Debug.Log(b);
                spawnPoints[b].GetComponent<enemySpawner>().StartCoroutine("spawnEnemy");
            }

            Debug.Log("Start waiting");
            yield return new WaitForSeconds(1.0f);
            Debug.Log("Done waiting");
        }
        canSpawn = true;
        yield break;
    }

    void Update()
    {
        Debug.Log(canSpawn);

        if (GameObject.FindWithTag("Enemy") == null && canSpawn == true)
        {
            StartCoroutine("calculateEnemies", ++currentWave);
            canSpawn = false;
        }
    }
}
