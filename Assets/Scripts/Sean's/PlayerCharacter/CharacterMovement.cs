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

   
    //here come wesley's additions!
    [SerializeField]
    private float spread = 0.5f;

    [SerializeField]
    private SmokeChainer pS;

    [SerializeField]
    private Transform pSH;

    [SerializeField]
    private bool swipeMove;

    [SerializeField]
    private bool minigunMove = true;

    [SerializeField]
    private bool[] moveBools = new bool[] {false, false, false, false};
    // leftMove; // 0
    // upMove; // 1
    // rightMove; // 2
    // downMove; // 3


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
        Debug.Log("moveByJST is called");
        
        if(swipeMove == false){
            rb2d.MovePosition((Vector2)this.transform.position +  mjst * Time.deltaTime * moveSpeed);

            if (!minigunMove) { Movejst.gameObject.SetActive(true); };
            if (minigunMove) { Movejst.gameObject.SetActive(false); }

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

        }  else if(swipeMove == true){

            Movejst.gameObject.SetActive(false);

            Debug.Log("swipemove is true");

            if (SwipeDetector.Instance.IsSwiping(Direction.left)){

                changeDirectionBool(0);
                
                Debug.Log("left");
            }
            else if (SwipeDetector.Instance.IsSwiping(Direction.right)){

                changeDirectionBool(1);

                Debug.Log("right");
            }
            else if (SwipeDetector.Instance.IsSwiping(Direction.up)){

                changeDirectionBool(2);
                Debug.Log("up");
            }
            else if (SwipeDetector.Instance.IsSwiping(Direction.down)){

                changeDirectionBool(3);
                Debug.Log("down");
            }
            else if (SwipeDetector.Instance.IsSwiping(Direction.none)){
                Debug.Log("no input detected");
            }

            
            if(moveBools[0] == true){

                mjst = Vector2.left;
                facingRight = false;

            
            } else if (moveBools[1] == true){
                
                mjst = Vector2.right;
                facingBack = true;
            
            } else if (moveBools[2] == true){
                
                
                mjst = Vector2.up;
                facingRight = true;
            
            } else if (moveBools[3] == true){
                
                mjst = Vector2.down;
                facingBack = false;

            }
            rb2d.MovePosition((Vector2)this.transform.position +  mjst * Time.deltaTime * moveSpeed);
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
            
            // add a slight spread to the gun.

            ajst = ajst + new Vector2 (Random.Range(-spread, spread), Random.Range(-spread, spread));

            tbp.ShootTo(ajst);
            pc.magazine--;

            if (minigunMove) { rb2d.AddForce(-ajst * Time.deltaTime * 100000 * pc.usingWeapon.knockbackToPlayer); };

            pS.PlayPS();
            pSH.rotation = Quaternion.Euler((Mathf.Atan2(ajst.y, ajst.x) * Mathf.Rad2Deg) * -1, 90, 0);
            cooldown = pc.usingWeapon.fireRate;


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

    private void changeDirectionBool(int SelectedBool){
        if(SelectedBool != null){
            for(int i = 0; i < moveBools.Length; i++){
                if (i == SelectedBool){
                    moveBools[i] = true;
                }
                else
                {
                    moveBools[i] = false;
                }
            }  
        }
    }
}
