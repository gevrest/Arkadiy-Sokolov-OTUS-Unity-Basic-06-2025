using UnityEngine;

namespace Character
{
    public class HealthComponent : MonoBehaviour
    {
        public int Health = 100;
        private bool _isDead = false;

        private void DealDamage(int damage)
        {
            if (!_isDead)
            {
                Health = Mathf.Max(0, Health - damage);
            }

            if (Health == 0)
            {
                _isDead = true;
                Destroy(gameObject);
            }
        }
    }
}