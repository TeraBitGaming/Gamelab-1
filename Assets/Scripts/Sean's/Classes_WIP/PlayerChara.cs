using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerChara : Character
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

    [SerializeField]
    private float pcMoveSpeed;

    public PlayerChara(int pcId, string pcName, int hitPoint, Ability abilityA, Ability abilityB, Passive passive, WeaponNew usingWeapon, float moveSpeed) : base(hitPoint)
    {
        this.pcId = pcId;
        this.pcName = pcName;
        this.pcAbilityA = abilityA;
        this.pcAbilityB = abilityB;
        this.pcPassive = passive;
        this.pcUsingWeapon = usingWeapon;
        this.pcMoveSpeed = moveSpeed;
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

    public float GetPCMoveSpeed()
    {
        return this.pcMoveSpeed;
    }

    public void MultiplySpeedBy(float ratio)
    {
        this.pcMoveSpeed *= ratio;
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
