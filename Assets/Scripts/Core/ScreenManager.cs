using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class ScreenManager : MonoBehaviour
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
