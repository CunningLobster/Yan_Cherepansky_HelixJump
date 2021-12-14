using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core; //Check If Possible To Refuse


public class Platform : MonoBehaviour
{
    [SerializeField] Vector3 cameraPositionOffset;
    [SerializeField] ParticleSystem crushEffect;
    ScoreManager scoreManager;
    AudioSource audioSource;
    new Collider collider;

    Sector[] sectors;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        scoreManager = FindObjectOfType<ScoreManager>();
        sectors = GetComponentsInChildren<Sector>();
        collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) { return; }
        audioSource.Play();
        //CameraFollow.isFalling = true;
        scoreManager.AddScore();
        foreach (Sector sector in sectors)
        {
            sector.Crush();
            crushEffect.gameObject.SetActive(true);
            collider.enabled = false;
        }
    }
}
