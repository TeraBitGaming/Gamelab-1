using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemProjectile : MonoBehaviour
{
    [SerializeField]
    private int damage;

    public void SetDamageTo(int i)
    {
        damage = i;
    }

    private void DealDamageToPlayer()
    {
        FindObjectOfType<PlayerCharacter>().HP -= damage;
    }

    private void OnBecameInvisible()
    {
        RecycleThis();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerCharacter>())
        {
            DealDamageToPlayer();
            RecycleThis();
        }
    }

    private void RecycleThis()
    {
        FindObjectOfType<TotemProjectilePool>().RecycleAProjectile(this.gameObject);
    }
}
