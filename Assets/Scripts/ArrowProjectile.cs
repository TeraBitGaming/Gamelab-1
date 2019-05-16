using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowProjectile : MonoBehaviour
{

    private PlayerCharacter pc;
    private Rigidbody2D rb;
    private ComboManager comboM;

    [SerializeField]
    private int speed;

    
    [SerializeField]
    private int damage;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        pc = FindObjectOfType<PlayerCharacter>();
        comboM = FindObjectOfType<ComboManager>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = -transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == pc.gameObject)
        {
            pc.HP -= damage;
            comboM.ResetCombo();
        }
        Destroy(gameObject);
    }
}
