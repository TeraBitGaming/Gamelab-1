using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Passive
{
    private int passiveId;
    private string passiveName;

    public Passive(int id, string name)
    {
        this.passiveId = id;
        this.passiveName = name;
    }

    public void Effect()
    {
        Debug.Log("Passive <" + this.passiveName + "> is effected.");
    }

    /// <summary>
    /// Please fold all methods below if you are not editing them.
    /// </summary>
    /// <returns></returns>
    public int GetPassiveId()
    {
        return this.passiveId;
    }

    public string GetPassiveName()
    {
        return this.passiveName;
    }
}