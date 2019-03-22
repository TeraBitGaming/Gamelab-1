using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Buff
{
    private int buffId;
    private string buffName;
    private float buffDuration;

    public Buff(int id, string name, float duration)
    {
        this.buffId = id;
        this.buffName = name;
        this.buffDuration = duration;
    }

    public void Effect()
    {
        Debug.Log("Buff <" + this.buffName + "> is effected.");
    }


    /// <summary>
    /// Please fold all methods below if you are not editing them.
    /// </summary>
    /// <returns></returns>
    public int GetBuffId()
    {
        return this.buffId;
    }

    public string GetBuffName()
    {
        return this.buffName;
    }

    public float GetBuffDuration()
    {
        return this.buffDuration;
    }

    public void SetBuffDuration(float newDuration)
    {
        this.buffDuration = newDuration;
    }
}