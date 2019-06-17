using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    public int combo = 0;

    public void AddToCombo(){
        combo += 1;
        // Debug.Log(combo);
        // CalculateComboNumbers(combo);
    }

    public void ResetCombo(){
        // Deprecated feature.
        // combo = 0;
        // CalculateComboNumbers(combo);
    }


    public string GetCombo()
    {
        return combo.ToString();
    }

    public int GetComboInt()
    {
        return combo;
    }
}
