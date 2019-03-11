using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    /// <summary>
    /// Note:
    /// 1)Player Direction.
    /// </summary>
    
    public CharacterMovement cm;

    public JoyStick mjst;
    public JoyStick ajst;

    public int HP;//Player Hitpoint.
    public int EG;//Player Energe.

    public Weapon usingWeapon;

    private void Awake()
    {
        cm = FindObjectOfType<CharacterMovement>();
        HP = 100;
        EG = 100;
    }

    private void Start()
    {
        usingWeapon = WeaponList.instance.weaponList[0];

    }

    public PlayerCharacter()
    {

    }

    public void Move()
    {
        cm.MoveByJst(mjst.value);
    }

    public void Attack()
    {
        cm.AttackByJst(ajst.value, usingWeapon);
    }

    public void Ability()
    {
        Debug.Log("Ability Used");
    }

}
