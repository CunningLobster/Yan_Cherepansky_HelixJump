using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        Rigidbody rb;
        AudioSource audioSource;
        Animator animator;
        [SerializeField] GameObject body;
        public GameObject Body => body;
        new Renderer renderer;

        [SerializeField] private float speed;
        public float Speed => speed;
        public Rigidbody Rb => rb;
        [SerializeField] private Vector3 maxVelocity;

        bool isDead = false;
        float minDissolveValue = -.2f;
        float maxDissolveValue = 1.1f;
        float timer = 0;
        [SerializeField] float dissolveTime;

        [SerializeField] ParticleSystem deathEffect;
        ParticleSystem.MainModule deathMain;
        [SerializeField] ParticleSystem winEffect;

        PlayerInput input;

        void Awake()
        {
            animator = GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>();
            rb = GetComponent<Rigidbody>();
            renderer = body.GetComponent<Renderer>();

            deathMain = deathEffect.main;
            deathMain.duration = dissolveTime;
            input = GetComponent<PlayerInput>();
        }

        private void FixedUpdate()
        {
            CheckVelocity();
        }

        private void Update()
        {
            if (isDead)
            {
                Dissolve();
            }

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
            animator.SetTrigger("bounce");
            Invoke("Jump", .1f);
        }

        void Jump()
        {
            rb.velocity = Vector3.up * speed;
        }

        public void Die()
        {
            rb.velocity = Vector3.zero;
            Debug.Log("Player is Dead");
            isDead = true;

            input.enabled = false;
        }

        void Dissolve()
        {
            Debug.Log(timer);
            float value = Mathf.Lerp(minDissolveValue, maxDissolveValue, timer / dissolveTime);
            timer += Time.deltaTime;

            renderer.material.SetFloat("Vector1_41d25d5831ab4ddda30512922c552c28", value);

            deathEffect.gameObject.SetActive(true);

        }

        public void ReachFinish()
        {
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
            body.GetComponent<MeshRenderer>().enabled = false;
            winEffect.gameObject.SetActive(true);
            Debug.Log("Player Wins");

            input.enabled = false;
        }
    }
}
