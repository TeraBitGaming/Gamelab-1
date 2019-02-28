using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public JoyStick jst;

    private Rigidbody2D rb2d;

    [Range(0.0f, 100.0f)]
    public float moveSpeed = 20.0f;

    private void Awake()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }

    void Walk()
    {
        rb2d.MovePosition((Vector2)this.transform.position +  jst.value * Time.deltaTime * moveSpeed);
    }
}
