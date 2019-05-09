using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempWeaponPickUps : MonoBehaviour
{
    private PlayerCharacter pc;
    [SerializeField]
    private Weapon wp;

    private void Awake()
    {
        pc = FindObjectOfType<PlayerCharacter>();
    }

    public void ChangeWeapon(Weapon wp)
    {
        pc.ChangeWeapon(wp);
    }
}
