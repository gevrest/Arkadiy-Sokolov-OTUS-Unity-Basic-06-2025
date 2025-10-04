using UnityEngine;

namespace Game
{
    public abstract class HealthComponent : MonoBehaviour
    {
        [SerializeField] protected int _health = 100;
        [SerializeField] protected int _maxHealth = 100;

        public abstract void DealDamage(int damage);

        protected abstract void Death();

        public void Heal(int healing)
        {
            _health = Mathf.Min(_maxHealth, _health + healing);
        }
    }
}