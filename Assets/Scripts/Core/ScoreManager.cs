using UnityEngine;

namespace Core
{
    public class ScoreManager : MonoBehaviour
    {
        int currentScore;
        static int bestScore = 0;

        public int CurrentScore => currentScore;
        public static int BestScore => bestScore;

        public void AddScore()
        {
            currentScore += 10;

            if (bestScore < currentScore)
                bestScore = currentScore;
        }
    }
}
