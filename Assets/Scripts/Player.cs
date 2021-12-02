using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] private float speed;
    public float Speed => speed;
    public Rigidbody Rb => rb;

    bool isBounced;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (rb.velocity.y < 0)
        { 
            isBounced = false;
        }
    }

    public void Bounce()
    {
        if (isBounced) return;
        isBounced = true;
        rb.AddForce(Vector3.up * speed, ForceMode.VelocityChange);
    }

    public void Die()
    {
        rb.velocity = Vector3.zero;
        Debug.Log("Player is Dead");
    }

    public void ReachFinish()
    {
        rb.velocity = Vector3.zero;
        Debug.Log("Player Wins");
    }
}
