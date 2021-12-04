using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderProgress : MonoBehaviour
{
    Player player;
    Finish finish;
    Slider slider;

    float distanceToFinish;
    float startY;
    float finishY;
    float currentY;
    void Awake()
    {
        player = FindObjectOfType<Player>();
        finish = FindObjectOfType<Finish>();
        slider = GetComponent<Slider>();

        distanceToFinish = Vector3.Distance(player.transform.position, finish.transform.position);
        startY = player.transform.position.y;
        finishY = player.transform.position.y - distanceToFinish;

    }

    void Update()
    {
        currentY = Mathf.Min(currentY, player.transform.position.y);
        slider.value = Mathf.InverseLerp(startY, finishY, currentY);
    }
}