using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallbreakingScript : MonoBehaviour
{
    private int magnitude = 5;

    [SerializeField]
    private GameObject parent;

    void OnCollisionEnter2D(Collision2D collision){

        if (collision.relativeVelocity.magnitude > magnitude){
            parent.SetActive(false);
        }
    }
}
