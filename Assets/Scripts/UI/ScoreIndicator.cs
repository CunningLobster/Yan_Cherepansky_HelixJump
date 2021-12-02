using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreIndicator : MonoBehaviour
{
    ScoreManager scoreManager;
    [SerializeField] TMP_Text currentScoreText;
    [SerializeField] TMP_Text bestScoreText;

    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();

        bestScoreText.text = $"BEST: {ScoreManager.BestScore}";
    }

    private void Update()
    {
        currentScoreText.text = scoreManager.CurrentScore.ToString();
    }
}
