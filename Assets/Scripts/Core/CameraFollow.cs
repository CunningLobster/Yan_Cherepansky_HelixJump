using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static bool isFalling;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isFalling)
            rb.velocity = new Vector3(rb.velocity.x, FindObjectOfType<Player>().Rb.velocity.y, rb.velocity.z);
        else
            rb.velocity = Vector3.zero;
    }
}
