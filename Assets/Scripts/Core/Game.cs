using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

namespace Core
{
    public class Game : MonoBehaviour
    {
        [SerializeField] public UnityEvent OnPlayerDied;
        [SerializeField] public UnityEvent OnPlayerFinished;

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void LoadNextLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
