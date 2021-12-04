using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] Vector3 cameraPositionOffset;
    ScoreManager scoreManager;
    AudioSource audioSource;

    Sector[] sectors;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        scoreManager = FindObjectOfType<ScoreManager>();
        sectors = GetComponentsInChildren<Sector>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) { return; }
        audioSource.Play();
        CameraFollow.isFalling = true;
        scoreManager.AddScore();
        foreach (Sector sector in sectors)
        {
            sector.Crush();
        }
    }
}
