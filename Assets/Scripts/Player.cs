using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;

    [SerializeField] private float speed;
    public float Speed => speed;
    public Rigidbody Rb => rb;
    [SerializeField] private Vector3 maxVelocity;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        CheckVelocity();
    }

    private void CheckVelocity()
    {
        float dot = Vector3.Dot(rb.velocity.normalized, maxVelocity.normalized);
        if (rb.velocity.sqrMagnitude >= maxVelocity.sqrMagnitude && dot > .7f)
            rb.velocity = maxVelocity;
    }

    public void Bounce()
    {
        audioSource.Play();
        rb.velocity = Vector3.up * speed;
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
