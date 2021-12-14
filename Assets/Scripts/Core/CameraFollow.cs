using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Rigidbody playerRb;
    [SerializeField] Vector3 cameraOffset;

    private void Awake()
    {
        transform.position = playerRb.position + cameraOffset;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Min(transform.position, playerRb.position + cameraOffset); 
    }

    private void OnValidate()
    {
        transform.position = playerRb.position + cameraOffset;
    }
}

