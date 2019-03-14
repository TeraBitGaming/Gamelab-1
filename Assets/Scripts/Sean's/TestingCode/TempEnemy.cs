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

    private void Awake()
    {
        pc = FindObjectOfType<PlayerCharacter>();
        rb2d = this.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ApproachPlayer();
    }

    void ApproachPlayer()
    {
        TurnToPlayer();
        rb2d.MovePosition(Vector2.MoveTowards(this.transform.position, pc.transform.position, moveSpeedEnemy));
        //Debug.Log(Vector2.Distance(this.transform.position, pc.gameObject.transform.position));
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
            pc.HP -= 10;
        }
    }
}
