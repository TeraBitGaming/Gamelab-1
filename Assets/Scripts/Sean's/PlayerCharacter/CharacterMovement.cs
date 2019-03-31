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
    public float moveSpeed = 20.0f;

    //!
    private float attackDistance = 1.5f;

    //!
    private int attack = 20;

    //!
    public float cooldown = 0;

    private void Awake()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        pc = FindObjectOfType<PlayerCharacter>();
    }

    private void FixedUpdate()
    {
        pc.Move();
        pc.Attack();
        UpdateCooldown();
    }

    /// <summary>
    /// Move the player based on the input of joystick. Ver 1.0.0
    /// </summary>
    public void MoveByJst(Vector2 mjst)
    {
        rb2d.MovePosition((Vector2)this.transform.position +  mjst * Time.deltaTime * moveSpeed);
    }

    public void AttackByJst(Vector2 ajst, Weapon wp)
    {
        if(cooldown <= 0)
        {

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
            cooldown = 0.5f;
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
}
