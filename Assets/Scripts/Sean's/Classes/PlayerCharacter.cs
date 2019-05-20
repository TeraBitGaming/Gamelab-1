﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    /// <summary>
    /// Note:
    /// 1)Player Direction.
    /// </summary>
    
    public CharacterMovement cm;

    public JoyStick mjst;
    public JoyStick ajst;

    public int HP;//Player Hitpoint.
    public int EG;//Player Energe.
    
    public Weapon usingWeapon;
    public int magazine;
    public float reloadTime;

    private Audiomanager audioManager;

    private void Awake()
    {
        cm = FindObjectOfType<CharacterMovement>();
        magazine = usingWeapon.magazine;
        reloadTime = usingWeapon.secCostForReloading;
        HP = 200;
        EG = 100;

        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<Audiomanager>();
    }

    private void Update()
    {
        HPCheck();
        UpdateMagazineReload();
    }

    public void Move()
    {
        cm.MoveByJst(mjst.value);
    }

    public void Attack(Vector2 dir)
    {
        if (magazine > 0)
        {
            //cm.AttackByJst(ajst.value, null);
            cm.AttackByTouching(dir);
        
        } else
        {
            ReloadMagazine();
        }

    }

    private void ReloadMagazine()
    {
        if (reloadTime <= 0)
        {
            magazine = usingWeapon.magazine;
            reloadTime = usingWeapon.secCostForReloading;
        }
    }

    private void UpdateMagazineReload()
    {
        if(reloadTime > 0 && magazine <= 0)
        {
            reloadTime -= Time.deltaTime;
        }
    }

    public void Ability()
    {
        Debug.Log("Ability Used");
    }

    private void HPCheck()
    {
        if (this.HP <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        this.gameObject.SetActive(false);
    }

    public void ChangeWeapon(Weapon weapon)
    {
        this.usingWeapon = weapon;
        magazine = usingWeapon.magazine;
        reloadTime = usingWeapon.secCostForReloading;
    }
}
