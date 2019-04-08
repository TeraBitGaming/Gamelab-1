using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempEnemy : MonoBehaviour
{
    private PlayerCharacter pc;
    private Rigidbody2D rb2d;
    private EnemyPool emyp;

    [SerializeField]
    private float moveSpeedEnemy = 0.3f;

    [SerializeField]
    private int HitPoint;

    private int HP;

    [SerializeField]
    private int damage;


    private void Awake()
    {
        pc = FindObjectOfType<PlayerCharacter>();
        rb2d = this.GetComponent<Rigidbody2D>();
        emyp = FindObjectOfType<EnemyPool>();
    }

    private void OnEnable()
    {
        HP = HitPoint;
    }

    void Start()
    {

    }

    void Update()
    {
        FlipSprite();
        ApproachPlayer();
    }

    public void ApproachPlayer()
    {
        if(pc)
        {
            if (Vector2.Distance(this.transform.position, pc.transform.position) < 38)
            {
                rb2d.MovePosition(Vector2.MoveTowards(this.transform.position, pc.transform.position, moveSpeedEnemy));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == pc.gameObject)
        {
            pc.HP -= damage;
        }
    }

    public void GetHit(int atk)
    {
        this.HP -= atk;
        if(this.HP <= 0)
        {
           Die();
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
        this.gameObject.SetActive(false);
        emyp.enemyPool.Add(this.gameObject);
    }
}
