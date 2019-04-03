using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempBullet : MonoBehaviour
{
    private TempBulletPool tbp;
    private PlayerCharacter pc;

    [SerializeField]
    private int bulletDamage = 20;

    private void Awake()
    {
        tbp = FindObjectOfType<TempBulletPool>();
        pc = FindObjectOfType<PlayerCharacter>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<TempEnemy>())
        {
            collision.gameObject.GetComponent<TempEnemy>().GetHit(bulletDamage);
        }
        this.gameObject.SetActive(false);
        tbp.BulletPool.Enqueue(this.gameObject);
    }
}
