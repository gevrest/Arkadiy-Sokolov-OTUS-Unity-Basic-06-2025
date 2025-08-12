using System.Collections;
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
            StartCoroutine(DamageEffect());

            if (_health <= 0)
            {
                Death();
            }
        }

        public void Heal(int healing)
        {
            _health = Mathf.Min(_maxHealth, _health + healing);
        }

        private void Death()
        {
            Destroy(gameObject);
        }

        private IEnumerator DamageEffect()
        {
            var renderer = gameObject.GetComponent<Renderer>();

            renderer.material.color = Color.red;
            yield return new WaitForSeconds(0.05f);
            renderer.material.color = Color.white;
        }
    }
}