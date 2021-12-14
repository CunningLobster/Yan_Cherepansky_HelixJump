using Player;//TO FIX
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class Sector : MonoBehaviour
{
    new Renderer renderer;

    [SerializeField] Material goodMaterial;
    [SerializeField] Material badMaterial;
    [SerializeField] bool isBad;
    [SerializeField] Vector3 crushVector;
    [SerializeField] Vector3 angularVelocity;

    Game game;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        UpdateMaterial();
        game = FindObjectOfType<Game>();
    }

    private void UpdateMaterial()
    {
        renderer = GetComponent<Renderer>();
        renderer.sharedMaterial = isBad ? badMaterial : goodMaterial;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Vector3.Dot(-collision.contacts[0].normal.normalized, Vector3.up) < .7f) return;
        if (!collision.gameObject.TryGetComponent(out PlayerController player)) return;

        //CameraFollow.isFalling = false;

        if (!isBad)
            player.Bounce();
        else
            game.OnPlayerDied?.Invoke();
    }

    public void Crush()
    {
        //rb.constraints = RigidbodyConstraints.None;
        rb.isKinematic = false;
        rb.AddForce(transform.forward * crushVector.z - transform.up * crushVector.y, ForceMode.Impulse);
        rb.angularVelocity = angularVelocity;
        Destroy(gameObject, 1f);
    }

    private void OnValidate()
    {
        UpdateMaterial();
    }
}
