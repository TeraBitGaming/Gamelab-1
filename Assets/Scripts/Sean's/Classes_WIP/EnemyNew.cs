using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyNew : Character
{
    private int enemyId;
    private string enemyName;
    private float enemyAtk;

    public EnemyNew(int id, string name, int hitPoint, int attack) : base(hitPoint)
    {
        this.enemyId = id;
        this.enemyName = name;
        this.enemyAtk = attack;
    }


    /// <summary>
    /// Please fold all methods below if you are not editing them.
    /// </summary>
    /// <returns></returns>
    public int GetEnemyId()
    {
        return this.enemyId;
    }

    public string GetEnemyName()
    {
        return this.enemyName;
    }

    public float GetEnemyAttack()
    {
        return this.enemyAtk;
    }

    public void SetEnemyAttack(float newAtk)
    {
        this.enemyAtk = newAtk;
    }

    public void MultiplyEnemyAttackBy(float ratio)
    {
        this.enemyAtk *= ratio;
    }
}