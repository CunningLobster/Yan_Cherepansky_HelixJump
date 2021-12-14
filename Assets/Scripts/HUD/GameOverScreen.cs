using UnityEngine;
using UnityEngine.SceneManagement;

namespace HUD
{
    public class GameOverScreen : MonoBehaviour
    {
        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}