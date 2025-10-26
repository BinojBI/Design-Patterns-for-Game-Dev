using UnityEngine;

namespace ObjectPooling
{
    public class Bullet : MonoBehaviour
    {
        public float lifeTime = 2f;

        private float timer;
        private ObjectPool pool;

        void OnEnable()
        {
            timer = lifeTime;
        }

        public void SetPool(ObjectPool objectPool)
        {
            pool = objectPool;
        }

        void Update()
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                if (pool != null)
                    pool.ReturnToPool(gameObject);
                else
                    Debug.LogWarning("Pool not assigned for bullet!");
            }
        }
    }
}
