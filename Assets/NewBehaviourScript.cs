using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Vector3 movingVector;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        movingVector = transform.InverseTransformDirection(movingVector);
    }

    
    void Update()
    {
        rb.velocity = transform.forward;
    }
}
