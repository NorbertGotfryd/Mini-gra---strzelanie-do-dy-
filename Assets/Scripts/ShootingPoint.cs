using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPoint : MonoBehaviour
{
    public static ShootingPoint instance;

    [SerializeField] private Transform projectilePrafab;

    private void Awake()
    {
        instance = this;
    }

    public void Shoot()
    {
        Transform projectileTransform = Instantiate(projectilePrafab, transform.position, Quaternion.identity);
        projectileTransform.GetComponent<Projectile>().ProjectilePhysic(PlayerController.instance.PlayerDirection());
    }
}
