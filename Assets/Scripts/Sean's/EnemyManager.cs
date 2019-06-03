using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    private EnemyPool emyp;

    [SerializeField]
    private int currentWave = 1;
    [SerializeField]
    private int enemiesCountForCurrentWave;
    [SerializeField]
    public List<GameObject> enemiesOfCurrentWave = new List<GameObject>();
    [SerializeField]
    private List<Transform> spawnLocs = new List<Transform>();
    [SerializeField]
    private Animator waveAnimt;
    [SerializeField]
    private Text waveDisplay;

    private void Awake()
    {
        var list = FindObjectsOfType<SpawnLoc>();
        for (int i = 0; i < list.Length; i++)
        {
            spawnLocs.Add(list[i].gameObject.transform);
        }

        emyp = FindObjectOfType<EnemyPool>();
    }

    private void Update()
    {
        WaveProcesser();
    }

    private void WaveProcesser ()
    {
        if(enemiesOfCurrentWave.Count == 0)
        {
            print("Current wave is: " + currentWave);
            ShowWave();
            SpawnNewWave();
        }
    }

    private void SpawnNewWave()
    {
        enemiesCountForCurrentWave = currentWave * 5 - 1;

        for (int i = 0; i < enemiesCountForCurrentWave; i++)
        {
            int spawnLocID = UnityEngine.Random.Range(0, spawnLocs.Count);
            var enemy = emyp.SpawnTo(spawnLocs[spawnLocID].position);
            enemiesOfCurrentWave.Add(enemy);
        }

        currentWave++;

    }

    private void ShowWave()
    {
        waveDisplay.GetComponent<Text>().text = "Wave " + currentWave;
        waveAnimt.SetTrigger("showWave");
    }
}
