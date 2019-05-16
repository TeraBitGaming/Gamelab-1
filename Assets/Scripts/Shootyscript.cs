using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootyscript : MonoBehaviour
{
    private int shootCooldown = 50;
    
    [SerializeField]
    private GameObject arrow;

    [SerializeField]
    private Vector3 shootDirection;

    // Detect if something is in the trigger
    void OnTriggerStay2D(Collider2D collider){
        
        // Detect if it's the player in the trigger,
        // and if it is start shooting.
        if (collider.gameObject.tag == "Player"){
            
            shootCooldown += 1;

            if (shootCooldown > 60){
                
                shootCooldown = 0;
                
                Instantiate(arrow, transform.position, Quaternion.Euler(shootDirection));
            }
        }
    }
}