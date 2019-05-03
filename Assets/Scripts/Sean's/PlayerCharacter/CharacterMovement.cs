﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public PlayerCharacter pc;
    /// <summary>
    /// Rigidbody2D of PlayerCharacter
    /// </summary>
    private Rigidbody2D rb2d;

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

    private float weaponCD = 1;


    
    //here come wesley's additions!
    [SerializeField]
    private SmokeChainer pS;

    [SerializeField]
    private Transform pSH;

    private void Awake()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        pc = FindObjectOfType<PlayerCharacter>();

        //!
        tbp = FindObjectOfType<TempBulletPool>();
    }

    private void FixedUpdate()
    {
        pc.Move();
        pc.Attack();
        UpdateCooldown();
        FlipPC();
    }

    /// <summary>
    /// Move the player based on the input of joystick. Ver 1.0.0
    /// </summary>
    public void MoveByJst(Vector2 mjst)
    {
        rb2d.MovePosition((Vector2)this.transform.position +  mjst * Time.deltaTime * moveSpeed);

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

            tbp.ShootTo(ajst);

            rb2d.AddForce(-ajst * Time.deltaTime * 50000);

            pS.PlayPS();
            pSH.rotation = Quaternion.Euler((Mathf.Atan2(ajst.y, ajst.x) * Mathf.Rad2Deg) * -1, 90, 0);
            cooldown = weaponCD;


            //Debug.DrawRay(pc.gameObject.transform.position, ajst.normalized * 1.5f, Color.red, 1f);
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
        }
        else
        {
            pc.gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        if(facingBack)
        {
            pc.GetComponent<Animator>().SetBool("facingBack", true);
        }
        else
        {
            pc.GetComponent<Animator>().SetBool("facingBack", false);
        }
    }

    public void ChangeWeaponCD(float cd)
    {
        this.weaponCD = cd;
    }
}
