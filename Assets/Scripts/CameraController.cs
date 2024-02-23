using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 cameraOffset;

    private void Start()
    {
        cameraOffset = new Vector3(0, 10, -10);
    }

    private void LateUpdate()
    {
        transform.position = Player.instance.transform.position + cameraOffset;
    }
}
