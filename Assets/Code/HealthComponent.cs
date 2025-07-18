using UnityEngine;

namespace Health
{
    public class HealthComponent : MonoBehaviour
    {
        public int MaxHealth = 100;
        public int Health = 100;
        public int Damage = 10;

        private bool _isDead = false;

        private void Start()
        {
            Debug.Log($"Press E to deal {Damage} damage to the target. The target has {Health} HP.");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && !_isDead)
            {
                DealDamage();
            }

            if (Input.GetKeyDown(KeyCode.Space) && _isDead)
            {
                RecoverTarget();
            }
        }

        public void DealDamage()
        {
            Health = Mathf.Max(0, Health - Damage);
            Debug.LogError($"Target HP: {Health}");

            if (Health == 0)
            {
                _isDead = true;
                Debug.LogWarning("The target was destroyed. Press space to recover the target");
            }
        }

        public void RecoverTarget()
        {
            Health = MaxHealth;
            _isDead = false;
            Debug.Log($"The target was recovered and has {Health} HP.");
        }
    }
}