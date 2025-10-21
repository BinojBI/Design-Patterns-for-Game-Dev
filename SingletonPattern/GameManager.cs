using UnityEngine;

namespace SingletonPattern
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public int playerScore = 0;

        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void AddScore(int amount)
        {
            playerScore += amount;
            Debug.Log("Player Score: " + playerScore);
        }
    }
}
