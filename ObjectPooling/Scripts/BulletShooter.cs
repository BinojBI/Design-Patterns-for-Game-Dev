using UnityEngine;

namespace ObjectPooling {
    public class BulletShooter : MonoBehaviour
    {
        public ObjectPool bulletPool;
        public Transform firePoint;
        public float bulletSpeed = 20f;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Fire();
            }
        }

        void Fire()
        {
            GameObject bullet = bulletPool.GetFromPool(firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.linearVelocity = firePoint.forward * bulletSpeed;
        }


    }
}
