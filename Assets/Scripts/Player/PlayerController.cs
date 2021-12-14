using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        Rigidbody rb;
        AudioSource audioSource;
        Animator animator;

        [SerializeField] private float speed;
        [SerializeField] private Vector3 maxVelocity;

        PlayerVFXHandler vfxHandler;
        PlayerInput input;

        void Awake()
        {
            animator = GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>();
            rb = GetComponent<Rigidbody>();

            input = GetComponent<PlayerInput>();
            vfxHandler = GetComponent<PlayerVFXHandler>();
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
            input.enabled = false;
            vfxHandler.ActivateDeathEffect();
        }

        public void ReachFinish()
        {
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
            input.enabled = false;
            vfxHandler.ActivateFinishEffect();
        }
    }
}
