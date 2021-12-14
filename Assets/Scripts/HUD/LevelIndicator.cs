using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelIndicator : MonoBehaviour
{
    int currentLevel;
    int nextLevel;

    public int CurrentLevel => currentLevel;

    [SerializeField] TMP_Text currentLevelText;
    [SerializeField] TMP_Text nextLevelText;

    private void Awake()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex + 1;
        nextLevel = currentLevel + 1;

        currentLevelText.text = currentLevel.ToString();
        nextLevelText.text = nextLevel.ToString();
    }

}
