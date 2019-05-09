using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponList : MonoBehaviour
{
    public static WeaponList instance;
    public List<Weapon> weaponList = new List<Weapon>();


    private void Awake()
    {
        instance = this;
        instantiateWeaponList();
    }

    private void instantiateWeaponList()
    {
        //weaponList.Add(new Weapon(0, "Testing Weapon", Weapon.WeaponType.Range, 0, 1.0f));
    }
}
