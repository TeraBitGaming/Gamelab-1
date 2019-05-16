using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class Weapon : ScriptableObject
{
    public Sprite image;
    public int damage;
    public float fireRate;
    [Range(0,1)]
    public float knockbackToEnemy;
    [Range(0,1)]
    public float knockbackToPlayer;
    public int magazine;
    public float secCostForReloading;
    [SerializeField]
    public FireModes fireMode;
    public enum FireModes
    {
        Single,
        ConeSpread
    };
    public int SpreadCount;
}
