using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    //public Queue<GameObject> enemyPool = new Queue<GameObject>();
    public List<GameObject> prefabs = new List<GameObject>();
    public List<GameObject> enemyPool = new List<GameObject>();

    [SerializeField]
    private int enemyCount = 20;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        instantiatePool();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void instantiatePool()
    {
        for(int j = 0; j < prefabs.Count; j++)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                var nmy = Instantiate(prefabs[j], this.gameObject.transform);
                nmy.SetActive(false);
                enemyPool.Add(nmy);
            }
        }
    }

    public void SpawnTo(Vector2 position)
    {
        int nmyId = Random.Range(0, enemyPool.Count);
        var nmy = enemyPool[nmyId];
        enemyPool.RemoveAt(nmyId);

        nmy.SetActive(true);
        nmy.transform.position = position;
    }
}
