using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody rigBody;
    [SerializeField] private float projectileForce;
    [SerializeField] private float destroyDelay;

    private void Awake()
    {
        rigBody = GetComponent<Rigidbody>();
    }

    public void ProjectilePhysic(Vector3 shootDirection)
    {
        rigBody.AddForce(shootDirection * projectileForce * Time.deltaTime, ForceMode.Impulse);
        Destroy(this.gameObject, destroyDelay);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
