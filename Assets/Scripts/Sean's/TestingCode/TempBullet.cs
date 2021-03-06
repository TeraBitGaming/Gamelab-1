﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempBullet : MonoBehaviour
{
    private TempBulletPool tbp;
    private PlayerCharacter pc;

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
            this.gameObject.SetActive(false);
        }
        if (collision.gameObject.GetComponent<TempBullet>())
        {

        }
        if (collision.gameObject.GetComponent<ExplodingScriptHPManager>())
        {
            collision.gameObject.GetComponent<ExplodingScriptHPManager>().HP -= 2;
        }
        else
        {
            this.gameObject.SetActive(false);
        }
        tbp.BulletPool.Enqueue(this.gameObject);
    }

    private void OnBecameInvisible()
    {
        this.gameObject.SetActive(false);
        tbp.BulletPool.Enqueue(this.gameObject);
    }

}
