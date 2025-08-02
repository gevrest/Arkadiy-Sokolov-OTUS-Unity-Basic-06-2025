using UnityEngine;

namespace Game
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int _health = 10;
        [SerializeField] private int _maxHealth = 100;

        public void Heal(int heal)
        {
            _health = Mathf.Min(_health +  heal, _maxHealth);
        }
    }
}