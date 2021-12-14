using UnityEngine;

namespace Core
{
    public class ScreenActivator : MonoBehaviour
    {
        [SerializeField] GameObject gameOverScreen;
        [SerializeField] GameObject levelPassedScreen;

        public void ActivateGameOverScreen()
        { 
            gameOverScreen.SetActive(true);
        }
        public void ActivateLevelPassedScreen()
        {
            levelPassedScreen.SetActive(true);
        }
    }

}
