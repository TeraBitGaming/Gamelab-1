using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public Queue<GameObject> enemyPool = new Queue<GameObject>();

    public GameObject prefab;

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
        for(int i = 0; i < enemyCount; i++)
        {
            var nmy = Instantiate(prefab, this.gameObject.transform);
            nmy.SetActive(false);
            enemyPool.Enqueue(nmy);
        }
    }

    public void SpawnTo(Vector2 position)
    {
        var nmy = enemyPool.Dequeue();
        nmy.SetActive(true);
        nmy.transform.position = position;
    }
}
