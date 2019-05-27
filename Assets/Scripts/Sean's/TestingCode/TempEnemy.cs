using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempEnemy : MonoBehaviour
{
    private PlayerCharacter pc;
    private Rigidbody2D rb2d;
    private EnemyPool emyp;

    [SerializeField]
    [Range(0.0f, 1.0f)]
    
    private float moveSpeedEnemy = 0.3f;
    private ComboManager comboM;

    [SerializeField]
    private int HitPoint;

    [SerializeField]
    private int HP;

    [SerializeField]
    private int damage;

    public EnemyManager emye;

    [SerializeField]
    private bool isDead = true;

    [SerializeField]
    private float CD = 1;
    private float currentCD = 0;

    [SerializeField]
    private bool isCollidingWithPC = false;



    private void Awake()
    {
        pc = FindObjectOfType<PlayerCharacter>();
        rb2d = this.GetComponent<Rigidbody2D>();
        comboM = FindObjectOfType<ComboManager>();
        emyp = FindObjectOfType<EnemyPool>();
        emye = FindObjectOfType<EnemyManager>();
    }

    private void OnEnable()
    {
        HP = HitPoint;
        isDead = false;
    }

    void Start()
    {

    }

    void Update()
    {
        FlipSprite();
        UpdateCD();
        rb2d.velocity = Vector2.zero;
    }

    private void FixedUpdate()
    {
        ApproachPlayer();
    }

    public void ApproachPlayer()
    {
        if(pc)
        {
            if (!isCollidingWithPC)
            {
                rb2d.MovePosition(Vector2.MoveTowards(this.transform.position, pc.transform.position, moveSpeedEnemy));
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerCharacter>())
        {
            Attack(collision.gameObject.GetComponent<PlayerCharacter>());
        }
    }

    private void Attack(PlayerCharacter pc)
    {
        if(currentCD <= 0)
        {
            DealDamageTo(pc);
            currentCD = CD;
            //Play attack animation
        }
    }

    private void DealDamageTo(PlayerCharacter pc)
    {
        pc.HP -= damage;
        comboM.ResetCombo();
    }

    private void UpdateCD()
    {
        if(currentCD > 0)
        {
            currentCD -= Time.deltaTime;
        }
    }

    public void GetHit(int atk)
    {
        if(!isDead)
        {
            this.HP -= atk;
            if (this.HP <= 0)
            {
                Die();
            }
            //print("Gethit is called");
        }
    }

    private void FlipSprite()
    {
        if(pc)
        {
            Vector2 pos = pc.gameObject.transform.position;
            if (pos.x > this.transform.position.x)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }

            if (pos.y > this.transform.position.y)
            {
                GetComponent<Animator>().SetBool("facingBack", true);
            }
            else
            {
                GetComponent<Animator>().SetBool("facingBack", false);

            }

        }
    }

    private void Die()
    {
        isDead = true;
        Vector2 deathPos = new Vector2 (transform.position.x, transform.position.y);
        emyp.DeathAt(deathPos);
        this.HP = this.HitPoint;
        this.gameObject.SetActive(false);
        emyp.enemyPool.Add(this.gameObject);
        emye.enemiesOfCurrentWave.Remove(this.gameObject);
        comboM.AddToCombo();
        //print("Die is called");
    }
}
