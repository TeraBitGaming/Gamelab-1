using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class Weapon : ScriptableObject
{
    public string name;
    public Sprite image;
    public int damage;
    public float fireRate;
    [Range(0,1)]
    public float knockbackToEnemy;
    [Range(0,2)]
    public float knockbackToPlayer;
    public int magazine;
    public float secCostForReloading;
    [SerializeField]
    public FireModes fireMode;
    public enum FireModes
    {
        Single,
        ConeSpread,
        EnergyWeapon
    };
    public int BulletPerShot;//For ConSpread type weapon, default is 0.
    public float SecCostForCharge;//For EnergyWeapon type weapon, defaul is 0.
    public int purchaseCost;
}
