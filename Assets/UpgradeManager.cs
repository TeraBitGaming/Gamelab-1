using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public LevelManagementScript moneyManager;
    public int level = 1;
    
    public void upgrade(int cost){
        if (moneyManager.gold >= cost && moneyManager.iron >= cost * 2){
            level += 1;
            moneyManager.gold -= cost;
            moneyManager.iron -= cost * 2;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
