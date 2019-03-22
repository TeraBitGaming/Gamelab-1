using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability
{
    private int abilityId;
    private string abilityName;
    private Damage abilityDamage;
    private float abilityColddown;
    private Animation abilityAnimation;

    public Ability(int id, string name, Damage dmg, float cd, Animation anim)
    {
        this.abilityId = id;
        this.abilityName = name;
        this.abilityDamage = dmg;
        this.abilityColddown = cd;
        this.abilityAnimation = anim;
    }

    public void Use()
    {
        Debug.Log("Ability <" + this.abilityName + "> is used.");
    }


    /// <summary>
    /// Please fold all methods below if you are not editing them.
    /// </summary>
    /// <returns></returns>
    public int GetAbilityId()
    {
        return this.abilityId;
    }

    public string GetAbilityName()
    {
        return this.abilityName;
    }

    public Damage GetAbilityDamage()
    {
        return this.abilityDamage;
    }

    public float GetAbilityColddown()
    {
        return this.abilityColddown;
    }
}