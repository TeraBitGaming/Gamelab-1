using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempBulletPool : MonoBehaviour
{
    public Queue<GameObject> BulletPool = new Queue<GameObject>();

    public GameObject prefab;

    [SerializeField]
    private int bulletCount = 20;

    [SerializeField]
    private float bulletSpeed = 2.0f;

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
        for(int i = 0; i < bulletCount; i++)
        {
            var bullet = Instantiate(prefab, this.gameObject.transform);
            bullet.SetActive(false);
            BulletPool.Enqueue(bullet);
        }
    }

    public void ShootTo(Vector2 dir)
    {
        if(BulletPool.Count > 0)
        {
            var bullet = BulletPool.Dequeue();
            var rb2db = bullet.GetComponent<Rigidbody2D>();
            bullet.SetActive(true);

            bullet.transform.position = FindObjectOfType<PlayerCharacter>().transform.position;

            float ang = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            bullet.transform.rotation = Quaternion.AngleAxis(ang, Vector3.forward);

            rb2db.AddForce(dir.normalized * 50000 * Time.deltaTime);
        }
    }
}
