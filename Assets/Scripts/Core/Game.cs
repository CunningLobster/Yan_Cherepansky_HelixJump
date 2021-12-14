using UnityEngine;
using UnityEngine.Events;

namespace Core
{
    public class Game : MonoBehaviour
    {
        [SerializeField] public UnityEvent OnPlayerDied;
        [SerializeField] public UnityEvent OnPlayerFinished;
    }
}
