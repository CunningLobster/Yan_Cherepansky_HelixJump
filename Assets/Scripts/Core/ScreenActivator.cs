using HUD;
using UnityEngine;

namespace Core
{
    public class ScreenActivator : MonoBehaviour
    {
        GameOverScreen gameOverScreen;
        LevelPassedScreen levelPassedScreen;

        private void Start()
        {
            gameOverScreen = FindObjectOfType<GameOverScreen>(true);
            levelPassedScreen = FindObjectOfType<LevelPassedScreen>(true);
        }

        public void ActivateGameOverScreen()
        { 
            gameOverScreen.gameObject.SetActive(true);
        }
        public void ActivateLevelPassedScreen()
        {
            levelPassedScreen.gameObject.SetActive(true);
        }
    }

}
