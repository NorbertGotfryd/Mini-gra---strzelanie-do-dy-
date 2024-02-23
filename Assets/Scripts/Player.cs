using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    public static Player instance;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        PlayerAnimation();
    }

    private void PlayerAnimation()
    {
        if (PlayerController.instance.horizontalInput != 0 || PlayerController.instance.verticalInput != 0)
            playerAnimator.SetBool("IsWalking", true);
        else
            playerAnimator.SetBool("IsWalking", false);
    }
}
