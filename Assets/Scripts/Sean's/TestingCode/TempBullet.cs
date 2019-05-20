using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempBullet : MonoBehaviour
{
    private TempBulletPool tbp;
    private PlayerCharacter pc;
    [SerializeField]
    private float decayTimeOfBullet = 3;
    private float timer = 0;

    private void Awake()
    {
        tbp = FindObjectOfType<TempBulletPool>();
        pc = FindObjectOfType<PlayerCharacter>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<TempEnemy>())
        {
            collision.gameObject.GetComponent<TempEnemy>().GetHit(pc.usingWeapon.damage);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce((collision.gameObject.transform.position - this.gameObject.transform.position).normalized * pc.usingWeapon.knockbackToEnemy * 100000 * Time.deltaTime);
            RecycleBullet();
        }
    }

    private void Update()
    {
        DecayTimer();
    }

    private void OnBecameInvisible()
    {
        RecycleBullet();
    }

    private void DecayTimer()
    {
        if(timer >= decayTimeOfBullet)
        {
            RecycleBullet();
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    private void RecycleBullet()
    {
        this.timer = 0;
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        this.gameObject.SetActive(false);

        tbp.BulletPool.Enqueue(this.gameObject);
    }

}
