using System.Collections;
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

    private void Awake()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        pc = FindObjectOfType<PlayerCharacter>();
    }

    private void FixedUpdate()
    {
        pc.Move();
        pc.Attack();
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
        //print(ajst);
        wp.Attack();
    }
}
