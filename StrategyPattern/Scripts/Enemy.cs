using UnityEngine;

namespace StrategyPattern
{
    public class Player : MonoBehaviour
    {
        public Transform enemy;
        private IAttackStrategy attackStrategy;

        void Start()
        {
            // Default attack strategy
            attackStrategy = new MeleeAttack();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                SetAttackStrategy(new MeleeAttack());
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                SetAttackStrategy(new RangedAttack());
            else if (Input.GetKeyDown(KeyCode.Alpha3))
                SetAttackStrategy(new MagicAttack());

            if (Input.GetKeyDown(KeyCode.Space))
                PerformAttack();
        }

        public void SetAttackStrategy(IAttackStrategy newStrategy)
        {
            attackStrategy = newStrategy;
            Debug.Log($"Switched to: {newStrategy.GetType().Name}");
        }

        public void PerformAttack()
        {
            attackStrategy?.Attack(transform, enemy);
        }

    }
}
