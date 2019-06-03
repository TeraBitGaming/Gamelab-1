using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJPool : MonoBehaviour
{
    public List<GameObject> prefabs = new List<GameObject>();
    public List<GameObject> objPool = new List<GameObject>();

    [SerializeField]
    private int objCount = 20;

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
            for (int i = 0; i < objCount; i++)
            {
                var obj = Instantiate(prefabs[j], this.gameObject.transform);
                obj.SetActive(false);
                objPool.Add(obj);
            }
        }
    }

    public GameObject SpawnTo(Vector2 position)
    {
        int objID = Random.Range(0, objPool.Count);
        var obj = objPool[objID];
        objPool.RemoveAt(objID);

        obj.SetActive(true);
        obj.transform.position = position;

        return obj;
    }
}