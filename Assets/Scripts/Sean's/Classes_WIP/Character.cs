using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character
{
    private float HP;

    public Character(int hitPoint)
    {
        this.HP = hitPoint;
    }


    /// <summary>
    /// Please fold all methods below if you are not editing them.
    /// </summary>
    /// <returns></returns>
    public float GetHP()
    {
        return this.HP;
    }

    public void SetHP(float newHP)
    {
        this.HP = newHP;
    }
}
