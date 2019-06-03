using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidTotem : MonoBehaviour
{
    [SerializeField]
    private float detectDistance = 15f;
    [SerializeField]
    private float cooldown = 3;
    private float CDTimer = -1;
    private PlayerCharacter pc;
    private Animator anmt;

    private void Start()
    {
        pc = FindObjectOfType<PlayerCharacter>();
        anmt = this.GetComponent<Animator>();
    }

    private void Update()
    {
        Attack();
        Timer();
    }

    private void Timer()
    {
        if(CDTimer > 0)
        {
            CDTimer -= Time.deltaTime;
        }
    }

    private void Attack()
    {
        if (CDTimer <= 0)
        {
            if (Vector2.Distance(pc.transform.position, this.transform.position) <= detectDistance)
            {
                anmt.SetTrigger("attack");
            }
        }
    }

    private void Shoot()
    {
        FindObjectOfType<TotemProjectilePool>().ShootToPlayer(this.transform.position);
        CDTimer = cooldown;
    }
}
