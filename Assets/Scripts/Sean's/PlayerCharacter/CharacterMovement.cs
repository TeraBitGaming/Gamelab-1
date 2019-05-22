using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random;

public class CharacterMovement : MonoBehaviour
{
    public PlayerCharacter pc;
    /// <summary>
    /// Rigidbody2D of PlayerCharacter
    /// </summary>
    private Rigidbody2D rb2d;

    public JoyStick Movejst;

    [Range(0.0f, 100.0f)]
    public float moveSpeed = 5.0f;

    private bool facingRight = true;
    private bool facingBack = false;

    /**
    //!
    private float attackDistance = 1.5f;

    //!
    private int attack = 20;
    **/

    //!
    public float cooldown = 0;
    

    //!
    private TempBulletPool tbp;

    [SerializeField]
    private int stdKB = 100000;

    private Vector2 moveAmount;

   
    //here come wesley's additions!
    [SerializeField]
    private float spread = 0.5f;

    private Audiomanager audioManager;

    // [SerializeField]
    // private SmokeChainer pS;

    [SerializeField]
    private Transform gun;

    [SerializeField]
    private SpriteRenderer gun2;

    private void Awake()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        pc = FindObjectOfType<PlayerCharacter>();

        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<Audiomanager>();

        //!
        tbp = FindObjectOfType<TempBulletPool>();
    }

    private void FixedUpdate()
    {
        pc.Move();
        //pc.Attack();
        UpdateCooldown();
        FlipPC();

        rb2d.AddForce(moveAmount, ForceMode2D.Force);
    }

    /// <summary>
    /// Move the player based on the input of joystick. Ver 1.0.0
    /// </summary>
    public void MoveByJst(Vector2 mjst)
    {
            // rb2d.MovePosition((Vector2)this.transform.position +  mjst * Time.deltaTime * moveSpeed);

            if(mjst.x > 0.01 || mjst.x < - 0.01 || mjst.y > 0.01 || mjst.y < -0.01)
            {
                pc.gameObject.GetComponent<Animator>().SetBool("isWalking", true);
            }
            else
            {
                pc.gameObject.GetComponent<Animator>().SetBool("isWalking", false);
            }

            if (mjst.x > 0.1)
            {
                //pc.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                facingRight = true;
            }
            if (mjst.x < -0.1)
            {
                //pc.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                facingRight = false;
            }

            if (mjst.y > 0.1)
            {
                facingBack = true;
            }
            if (mjst.y < -0.1)
            {
                facingBack = false;
            }

            // rb2d.MovePosition((Vector2)this.transform.position +  mjst * Time.deltaTime * moveSpeed);
        }

    public void AttackByJst(Vector2 ajst, Weapon wp)
    {
        if(cooldown <= 0)
        {
            /**
             * 
             * This piece of code is used for melee attack, which is not going to be used in the future version.
             * 
            RaycastHit2D atkRay = Physics2D.Raycast(pc.gameObject.transform.position, ajst, attackDistance, LayerMask.GetMask("Enemies"));
            Debug.DrawRay(pc.gameObject.transform.position, ajst * attackDistance, Color.yellow, 3);

            if (atkRay.collider != null)
            {
                TempEnemy enemy;
                enemy = atkRay.collider.GetComponent<TempEnemy>();

                enemy.GetHit(attack);
                enemy.GetComponent<Rigidbody2D>().AddForce(ajst.normalized * 500 * Time.deltaTime);
                
            }
            print("Player Attacked!");
            **/

            //From here is the shooting function.

            if (ajst.x > 0.1)
            {
                //pc.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                facingRight = true;
            }
            if (ajst.x < -0.1)
            {
                //pc.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                facingRight = false;
            }

            if (ajst.y > 0.1)
            {
                facingBack = true;
            }
            if (ajst.y < -0.1)
            {
                facingBack = false;
            }
            
            // add a slight spread to the gun.

            ajst = ajst + new Vector2 (Random.Range(-spread, spread), Random.Range(-spread, spread));

            tbp.ShootTo(ajst);
            pc.magazine--;

            moveAmount = -ajst * Time.fixedDeltaTime * stdKB * pc.usingWeapon.knockbackToPlayer;

            // pS.PlayPS();
            gun.rotation = Quaternion.Euler((Mathf.Atan2(ajst.y, ajst.x) * Mathf.Rad2Deg) * -1, 90, 0);

            cooldown = pc.usingWeapon.fireRate;


            //Debug.DrawRay(pc.gameObject.transform.position, ajst.normalized * 1.5f, Color.red, 1f);
        }
    }

    public void AttackByTouching(Vector2 dir)
    {
        if (cooldown <= 0)
        {
            #region Facing Selecter
            if (dir.x > 0.1)
            {
                //pc.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                facingRight = true;
            }
            if (dir.x < -0.1)
            {
                //pc.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                facingRight = false;
            }

            if (dir.y > 0.1)
            {
                facingBack = true;
            }
            if (dir.y < -0.1)
            {
                facingBack = false;
            }
            #endregion
            // add a slight spread to the gun.

            dir = dir + new Vector2(Random.Range(-spread, spread), Random.Range(-spread, spread));

            if(pc.usingWeapon.fireMode == Weapon.FireModes.Single)
            {
                tbp.ShootTo(dir);
            }else if(pc.usingWeapon.fireMode == Weapon.FireModes.ConeSpread)
            {
                for(int i = 0; i < pc.usingWeapon.SpreadCount; i++)
                {
                    tbp.ShootTo(dir + new Vector2(Random.Range(-spread, spread), Random.Range(-spread, spread)));
                }
            }
            
            pc.magazine--;

            rb2d.AddForce(-dir.normalized * Time.fixedDeltaTime * 100000 * pc.usingWeapon.knockbackToPlayer);

            // pS.PlayPS();
            gun.rotation = Quaternion.Euler((Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) * -1, 90, 0);
            audioManager.playSound(1);
            cooldown = pc.usingWeapon.fireRate;
        }
    }

    private void UpdateCooldown()
    {
        if(cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
    }

    private void FlipPC()
    {
        if(facingRight)
        {
            pc.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            gun2.flipY = false;
        }
        else
        {
            pc.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            gun2.flipY = true;
        }

        if(facingBack)
        {
            pc.GetComponent<Animator>().SetBool("facingBack", true);
            gun2.sortingOrder = 2;
        }
        else
        {
            pc.GetComponent<Animator>().SetBool("facingBack", false);
            gun2.sortingOrder = 5;
        }
    }
}
