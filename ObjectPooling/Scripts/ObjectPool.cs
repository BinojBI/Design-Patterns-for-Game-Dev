using UnityEngine;
using System.Collections.Generic;

namespace ObjectPooling
{
    public class ObjectPool : MonoBehaviour
    {
        [Header("Pool Settings")]
        public GameObject prefab;
        public int poolSize = 10;

        private Queue<GameObject> pool = new Queue<GameObject>();

        void Awake()
        {
            // Pre-instantiate all objects
            for (int i = 0; i < poolSize; i++)
            {
                GameObject obj = Instantiate(prefab);
                obj.SetActive(false);
                pool.Enqueue(obj);
            }
        }

        public GameObject GetFromPool(Vector3 position, Quaternion rotation)
        {
            if (pool.Count > 0)
            {
                GameObject obj = pool.Dequeue();
                obj.SetActive(true);
                obj.transform.SetPositionAndRotation(position, rotation);

                var bullet = obj.GetComponent<Bullet>();
                if (bullet != null)
                    bullet.SetPool(this);

                return obj;
            }

            //Expand pool if empty
            GameObject newObj = Instantiate(prefab, position, rotation);
            newObj.GetComponent<Bullet>().SetPool(this);
            return newObj;
        }

        public void ReturnToPool(GameObject obj)
        {
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

}
