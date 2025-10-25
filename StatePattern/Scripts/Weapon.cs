
using UnityEngine;

namespace StatePattern
{
    public class Weapon : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                var enemy = other.GetComponent<EnemyController>();
                if (enemy != null)
                {
                    enemy.TakeDamage();
                    Debug.Log($"Hit {other.name}, dealt damage!");
                }
            }
        }
    }
}
