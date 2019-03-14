using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon
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
    private string weapDescription;
    [SerializeField]
    private WeaponType weapType;
    [SerializeField]
    private int weapDamage;
    [SerializeField]
    private float attackRate;

    public Weapon(int wId, string wName, WeaponType wType, int wDmg, float wAttackrate, string wDescription = "No Description.")
    {
        this.weapId = wId;
        this.weapName = wName;
        this.weapType = WeaponType.Range;
        this.weapDamage = wDmg;
        this.attackRate = wAttackrate;
        this.weapDescription = wDescription;
    }

    public void Attack()
    {
        Debug.Log("Attacked");
    }
}
