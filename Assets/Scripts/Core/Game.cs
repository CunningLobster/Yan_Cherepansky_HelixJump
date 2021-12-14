using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    Player player;
    Controlls controlls;

    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject levelPassedScreen;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        controlls = FindObjectOfType<Controlls>();
    }

    public void OnPlayerDied()
    {
        player.Die();
        controlls.enabled = false;
        gameOverScreen.SetActive(true);
    }

    public void OnPlayerFinished()
    {
        player.ReachFinish();
        controlls.enabled = false;
        levelPassedScreen.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
