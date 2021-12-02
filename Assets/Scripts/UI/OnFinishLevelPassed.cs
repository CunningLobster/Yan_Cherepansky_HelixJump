using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnFinishLevelPassed : MonoBehaviour
{
    TMP_Text levelPassedText;
    LevelIndicator levelIndicator;

    private void Awake()
    {
        levelPassedText = GetComponent<TMP_Text>();
        levelIndicator = FindObjectOfType<LevelIndicator>();
    }

    private void OnEnable()
    {
        levelPassedText.text = $"Level {levelIndicator.CurrentLevel} Passed";
    }
}
