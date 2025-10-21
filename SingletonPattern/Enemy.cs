
using UnityEngine;

namespace SingletonPattern
{
    public class Enemy : MonoBehaviour
    {
        public void HitEnemy()
        {
            GameManager.Instance.AddScore(10);
        }
    }

}