using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OnGameOverProgress : MonoBehaviour
{
    TMP_Text progressText;
    Slider slider;

    private void Awake()
    {
        progressText = GetComponent<TMP_Text>();
        slider = FindObjectOfType<Slider>();
    }

    private void OnEnable()
    {
        float progressValue = Mathf.FloorToInt(slider.value * 100);
        progressText.text = $"{progressValue}% PASSED";
    }
}
