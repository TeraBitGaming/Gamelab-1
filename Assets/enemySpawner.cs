using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject enemyDataHolder;
    private int R;

    private bool canSpawn = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        canSpawn = false;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        canSpawn = true;
    }

    public IEnumerator spawnEnemy()
    {

        if (enemies.Length == 0)
        {
            enemies = enemyDataHolder.GetComponent<EnemyHolder>().spawnableEnemies;
        }
        
        yield return new WaitUntil(() => canSpawn == true);

        InstantiateEnemy();
    }

    private void InstantiateEnemy()
    {
        R = Random.Range(0, enemies.Length);
        Instantiate(enemies[R], transform.position, Quaternion.identity);
    }
}
