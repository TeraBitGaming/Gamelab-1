using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerClass : Character
{
    [SerializeField]
    private int pcId;
    [SerializeField]
    private string pcName;

    [SerializeField]
    private Ability pcAbilityA;
    [SerializeField]
    private Ability pcAbilityB;
    [SerializeField]
    private Passive pcPassive;
    [SerializeField]
    private WeaponNew pcUsingWeapon;

    public PlayerClass(int pcId, string pcName, int hitPoint = 100, Ability abilityA = null, Ability abilityB = null, Passive passive = null, WeaponNew usingWeapon = null) : base(hitPoint)
    {
        this.pcId = pcId;
        this.pcName = pcName;
        this.pcAbilityA = abilityA;
        this.pcAbilityB = abilityB;
        this.pcPassive = passive;
        this.pcUsingWeapon = usingWeapon;
    }


    public void Attack()
    {
        pcUsingWeapon.Attack();
    }


    /// <summary>
    /// Please fold all methods below if you are not editing them.
    /// </summary>
    /// <returns></returns>
    public int GetPCId()
    {
        return this.pcId;
    }

    public string GetPCName()
    {
        return this.pcName;
    }

    public WeaponNew GetPCUsingWeapon()
    {
        return this.pcUsingWeapon;
    }

    public void SetPCUsingWeapon (WeaponNew newWeapon)
    {
        this.pcUsingWeapon = newWeapon;
    }

    public void UseAbilityA()
    {
        pcAbilityA.Use();
    }

    public void UseAbilityB()
    {
        pcAbilityB.Use();
    }
}
