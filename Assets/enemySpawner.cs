using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    private GameObject[] enemies;
    private int R;
    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectWithTag("Rooms").GetComponent<EnemyHolder>().enemies;
        R = Random.Range(0, enemies.Length);
        Instantiate(enemies[R], transform.position, Quaternion.identity);
    }
}
