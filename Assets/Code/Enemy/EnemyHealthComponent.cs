using System.Collections;
using UnityEngine;

namespace Game
{
    public sealed class EnemyHealthComponent : HealthComponent
    {
        [SerializeField] private Color _damageColor = Color.red;
        [Space(10f)]
        [SerializeField] private Renderer _renderer;
        [SerializeField] private EnemyResponseTrigger _responseTrigger;
        
        private Color _defaultColor;

        private void Start()
        {
            _defaultColor = _renderer.material.color;
        }

        public override void DealDamage(int damage)
        {
            _health = Mathf.Max(0, _health - damage);

            StartCoroutine(DamageEffect());
            StartCoroutine(_responseTrigger.EnemyAttackedResponce());

            if (_health <= 0)
            {
                Death();
            }
        }

        private IEnumerator DamageEffect()
        {
            _renderer.material.color = _damageColor;
            yield return new WaitForSeconds(0.05f);
            _renderer.material.color = _defaultColor;
        }

        protected override void Death()
        {
            Destroy(gameObject);
        }
    }
}