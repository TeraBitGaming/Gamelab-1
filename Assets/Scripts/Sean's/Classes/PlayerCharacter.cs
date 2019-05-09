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
    
    public enum Weapons
    {
        Revolver,
        DualPistol,
        Minigun
    }
    public Weapons usingWeapon;

    public int attack = 50;

    //Weapon, bullet per sec
    public Dictionary<Weapons, float> weaponRatio = new Dictionary<Weapons, float>();
    public Dictionary<Weapons, int> weaponAtk = new Dictionary<Weapons, int>();

    private void instantiateWeaponAtk()
    {
        weaponAtk.Add(Weapons.Revolver, 50);
        weaponAtk.Add(Weapons.DualPistol, 15);
        weaponAtk.Add(Weapons.Minigun, 2);
    }

    private void instantiateWeaponRatio()
    {
        weaponRatio.Add(Weapons.Revolver, 1);
        weaponRatio.Add(Weapons.DualPistol, 0.3f);
        weaponRatio.Add(Weapons.Minigun, 0.02f);
    }

    private void Awake()
    {
        cm = FindObjectOfType<CharacterMovement>();
        HP = 200;
        EG = 100;
    }

    private void Start()
    {
        usingWeapon = Weapons.Minigun;
        instantiateWeaponRatio();
        instantiateWeaponAtk();
    }

    private void Update()
    {
        HPCheck();
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
        if (Mathf.Abs(ajst.value.x) > 0.1f || Mathf.Abs(ajst.value.y) > 0.1f)
        {
            cm.AttackByJst(ajst.value, null);
        }
    }

    public void Ability()
    {
        Debug.Log("Ability Used");
    }

    private void HPCheck()
    {
        if (this.HP <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        this.gameObject.SetActive(false);
    }

    public void ChangeWeapon(int wp)
    {
        this.usingWeapon = (Weapons)wp;
        this.attack = this.weaponAtk[usingWeapon];
        GetComponent<CharacterMovement>().ChangeWeaponCD(this.weaponRatio[usingWeapon]);
    }
}
