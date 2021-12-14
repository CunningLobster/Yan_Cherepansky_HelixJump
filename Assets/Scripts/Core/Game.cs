using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Player; //TO FIX

public class Game : MonoBehaviour
{
    PlayerController player;
    PlayerInput controlls;

    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject levelPassedScreen;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        controlls = FindObjectOfType<PlayerInput>();
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
