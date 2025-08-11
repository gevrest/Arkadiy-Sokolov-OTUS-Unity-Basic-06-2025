using UnityEngine;

namespace Game
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int _health = 100;
        [SerializeField] private int _maxHealth = 100;

        public void DealDamage(int damage)
        {
            _health = Mathf.Max(0, _health - damage);
            if (_health <= 0)
            {
                Death();
            }
        }

        public void Heal(int healing)
        {
            _health = Mathf.Min(_maxHealth, _health + healing);
        }

        public void Death()
        {
            Destroy(gameObject);
        }
    }
}