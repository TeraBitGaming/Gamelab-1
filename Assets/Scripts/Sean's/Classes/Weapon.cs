using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public float SecCostForReloading;
}
