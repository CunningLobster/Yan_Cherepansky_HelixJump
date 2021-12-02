using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sector : MonoBehaviour
{
    new Renderer renderer;

    [SerializeField] Material goodMaterial;
    [SerializeField] Material badMaterial;
    [SerializeField] bool isBad;

    private void Awake()
    {
        UpdateMaterial();
    }

    private void UpdateMaterial()
    {
        renderer = GetComponent<Renderer>();
        renderer.sharedMaterial = isBad ? badMaterial : goodMaterial;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Vector3.Dot(-collision.contacts[0].normal.normalized, Vector3.up) < .7f) return;
        if (!collision.gameObject.TryGetComponent(out Player player)) return;

        CameraFollow.isFalling = false;

        if (!isBad)
            player.Bounce();
        else
            FindObjectOfType<Game>().OnPlayerDied();
    }

    private void OnValidate()
    {
        UpdateMaterial();
    }
}
