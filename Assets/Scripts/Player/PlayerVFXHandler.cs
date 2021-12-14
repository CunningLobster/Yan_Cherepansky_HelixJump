using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerVFXHandler : MonoBehaviour
    {
        [SerializeField] public GameObject body;

        float minDissolveValue = -.2f;
        float maxDissolveValue = 1.1f;
        float timer = 0;
        [SerializeField] public float dissolveTime;

        new Renderer renderer;

        [SerializeField] public ParticleSystem deathEffect;
        ParticleSystem.MainModule deathMain;
        [SerializeField] public ParticleSystem winEffect;

        private void Awake()
        {
            renderer = body.GetComponent<Renderer>();
            deathMain = deathEffect.main;
            deathMain.duration = dissolveTime;
        }

        IEnumerator Dissolve()
        {
            while (timer <= dissolveTime)
            {
                Debug.Log(timer);
                float value = Mathf.Lerp(minDissolveValue, maxDissolveValue, timer / dissolveTime);
                timer += Time.deltaTime;

                renderer.material.SetFloat("Vector1_41d25d5831ab4ddda30512922c552c28", value);
                yield return null;
            }
        }

        public void ActivateDeathEffect()
        {
            StartCoroutine(Dissolve());
            deathEffect.gameObject.SetActive(true);
        }

        public void ActivateFinishEffect()
        {
            body.GetComponent<MeshRenderer>().enabled = false;
            winEffect.gameObject.SetActive(true);
        }
    }
}