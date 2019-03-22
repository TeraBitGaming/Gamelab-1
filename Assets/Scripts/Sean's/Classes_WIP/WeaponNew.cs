using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponNew
{
    public enum WeaponType
    {
        Melee,
        Range
    }
    [SerializeField]
    private int weapId;
    [SerializeField]
    private string weapName;
    [SerializeField]
    private WeaponType weapType;
    [SerializeField]
    private Damage weapDmg;
    [SerializeField]
    private float weapAtkRatio;

    public WeaponNew(int id, string name, WeaponType wType, Damage dmg, float ratio)
    {
        this.weapId = id;
        this.weapName = name;
        this.weapType = wType;
        this.weapDmg = dmg;
        this.weapAtkRatio = ratio;
    }

    public void Attack()
    {
        Debug.Log("Player attacked with weapon <" + this.weapName + ">.");
    }


    /// <summary>
    /// Please fold all methods below if you are not editing them.
    /// </summary>
    /// <returns></returns>
    public int GetWeaponId()
    {
        return this.weapId;
    }

    public string GetWeaponName()
    {
        return this.weapName;
    }

    public WeaponType GetWeaponType()
    {
        return this.weapType;
    }

    public Damage GetWeaponDamage()
    {
        return this.weapDmg;
    }

    public void SetWeaponDamage(Damage newDmg)
    {
        this.weapDmg = newDmg;
    }

    public float GetWeaponAttackRatio()
    {
        return this.weapAtkRatio;
    }

    public void SetWeaponAttackRatio(float newRatio)
    {
        this.weapAtkRatio = newRatio;
    }
}
