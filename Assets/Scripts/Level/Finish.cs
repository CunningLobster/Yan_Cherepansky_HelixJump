using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class Finish : MonoBehaviour
{
    Game game;

    private void Awake()
    {
        game = FindObjectOfType<Game>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        game.OnPlayerFinished?.Invoke();
    }
}
