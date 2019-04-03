using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempEnemy : MonoBehaviour
{
    private PlayerCharacter pc;
    private Rigidbody2D rb2d;

    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float moveSpeedEnemy = 0.05f;

    private int HP = 50;
    private int damage = 20;


    private void Awake()
    {
        pc = FindObjectOfType<PlayerCharacter>();
        rb2d = this.GetComponent<Rigidbody2D>();
    }

    void Start()
    {

    }

    void Update()
    {
       
    }

    public void ApproachPlayer()
    {
        if (Vector2.Distance(this.transform.position, pc.transform.position) < 38)
        {
            TurnToPlayer();
            rb2d.MovePosition(Vector2.MoveTowards(this.transform.position, pc.transform.position, moveSpeedEnemy));
        }
    }

    /// <summary>
    /// Turn the direction to player function, change to direction switch when enemy spritesheet is done.
    /// </summary>
    private Vector3 vec3ToTar;
    private float angle;
    void TurnToPlayer()
    {
        /**
        vec3ToTar = pc.gameObject.transform.position - this.transform.position;
        angle = Mathf.Atan2(vec3ToTar.y, vec3ToTar.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        **/

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
            this.gameObject.SetActive(false);
        }
    }
}
