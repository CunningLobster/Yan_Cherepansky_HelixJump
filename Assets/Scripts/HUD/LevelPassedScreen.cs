using UnityEngine;
using UnityEngine.SceneManagement;

namespace HUD
{
    public class LevelPassedScreen : MonoBehaviour
    {
        public void LoadNextLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}