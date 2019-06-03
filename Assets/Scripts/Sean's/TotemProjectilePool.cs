using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemProjectilePool : MonoBehaviour
{
    [SerializeField]
    private int poolCapacity;
    [SerializeField]
    private int dmgPerProjectile;
    [SerializeField]
    private GameObject ProjectilePrefab;
    [SerializeField]
    public Queue<GameObject> ProjectilePool = new Queue<GameObject>();
    [SerializeField]
    private float velocity;

    private PlayerCharacter pc;

    private void Start()
    {
        pc = FindObjectOfType<PlayerCharacter>();
        InstantiatePool();
    }

    private void InstantiatePool()
    {
        for(int i = 0; i < poolCapacity; i++)
        {
            var projectile = Instantiate(ProjectilePrefab, FindObjectOfType<TotemProjectilePool>().transform);
            projectile.GetComponent<TotemProjectile>().SetDamageTo(dmgPerProjectile);
            ResetProjectile(projectile);
            ProjectilePool.Enqueue(projectile);
        }
    }

    private GameObject GetAProjectile()
    {
        var projectile = ProjectilePool.Dequeue();
        projectile.SetActive(true);
        return projectile;
    }

    public void RecycleAProjectile(GameObject projectile)
    {
        ResetProjectile(projectile);
        ProjectilePool.Enqueue(projectile);
    }

    private void ResetProjectile(GameObject projectile)
    {
        projectile.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        projectile.transform.position = Vector2.zero;
        projectile.SetActive(false);
    }

    public void ShootToPlayer(Vector2 startPosition)
    {
        var dirVector = ((Vector2)(pc.transform.position)-(startPosition)).normalized;
        var projectile = GetAProjectile();
        projectile.transform.position = startPosition;
        projectile.GetComponent<Rigidbody2D>().velocity = dirVector * velocity;
    }
}
