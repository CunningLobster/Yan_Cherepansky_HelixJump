using UnityEngine;
using Core;

namespace Level
{
    public class Finish : MonoBehaviour
    {
        Game game;

        private void Awake()
        {
            game = FindObjectOfType<Game>();
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.CompareTag("Player")) return;
            game.OnPlayerFinished?.Invoke();
        }
    }
}
