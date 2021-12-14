using UnityEngine;
using Core;

namespace Level
{
    public class Platform : MonoBehaviour
    {
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
            scoreManager.AddScore();
            foreach (Sector sector in sectors)
            {
                sector.Crush();
                crushEffect.gameObject.SetActive(true);
                collider.enabled = false;
            }
        }
    }

}
