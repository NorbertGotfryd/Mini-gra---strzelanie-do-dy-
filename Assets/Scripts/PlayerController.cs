using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Transform projectileTransform;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float playerAttackCooldown;

    private float playerLastAttackedAt;
    public float horizontalInput { get; private set; }
    public float verticalInput { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        MousePosition();
        ShootProjectile();
    }

    private void FixedUpdate()
    {
        PlayerMove();
        RotatePlayer();
    }

    private void PlayerMove()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        rb.MovePosition(transform.position + ((new Vector3(1, 0, 0) * horizontalInput) + (new Vector3(0, 0, 1) * verticalInput)) * playerSpeed * Time.deltaTime);
    }

    private static Vector3 MousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, instance.layerMask);
        return raycastHit.point;
    }

    public Vector3 PlayerDirection()
    {
        Vector3 direction = (MousePosition() - transform.position).normalized;
        return direction;
    }

    private void RotatePlayer()
    {
        if (MousePosition() != Vector3.zero)
            transform.forward = PlayerDirection();
    }

    private void ShootProjectile()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > playerLastAttackedAt + playerAttackCooldown)
        {
            ShootingPoint.instance.Shoot();
            playerLastAttackedAt = Time.time;
        }
    }

}
