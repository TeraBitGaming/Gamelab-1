using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Damage
{ 
    private Character dmgObj;
    private float dmgAmount;
    private DamageModes dmgMode;
    private Vector2 dmgAoeCenter;
    public enum DamageModes
    {
        Empty,
        Directly,
        AoE,
        DoT
    }

    public Damage(Character chara, DamageModes mode = DamageModes.Directly, float amt = 0)
    {
        this.dmgObj = chara;
        if(mode == DamageModes.Empty)
        {
            this.dmgAmount = 0;
        }
        else
        {
            this.dmgAmount = amt;
        }
    }

    /// <summary>
    /// Deal damage to a character.
    /// </summary>
    public void Deal()
    {
        float newHP = dmgObj.GetHP() - this.dmgAmount;
        dmgObj.SetHP(newHP);
    }

    /// <summary>
    /// Deal damage direclty to a character.
    /// Note: Need to implement the DamageMode
    /// </summary>
    /// <param The object that get damaged="chara"></param>
    /// <param Damage mode="mode"></param>
    /// <param Damage amount="amt"></param>
    public static void DealDamageTo(Character chara, DamageModes mode = DamageModes.Directly, float amt = 0)
    {
        float newHP = chara.GetHP() - amt;
        chara.SetHP(newHP);
    }


    /// <summary>
    /// Please fold all methods below if you are not editing them.
    /// </summary>
    /// <returns></returns>
    public Character GetDamagedCharacter()
    {
        return this.dmgObj;
    }

    public float GetDamageAmout()
    {
        return this.dmgAmount;
    }

    public void MultiplyDamageAmoutBy(float ratio)
    {
        this.dmgAmount *= ratio;
    }
}
