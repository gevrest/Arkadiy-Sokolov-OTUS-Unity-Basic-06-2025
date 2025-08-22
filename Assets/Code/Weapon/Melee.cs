using UnityEngine;

namespace Game
{
    public class Melee : Weapon
    {
        [SerializeField] Transform _attackPosition;
        [SerializeField] int _damage;
        [SerializeField] float _attackDistance;
        [SerializeField] float _attackCooldown;

        private bool _canAttack;
        private float _lastAttackTime;

        private void Update()
        {
            _canAttack = _attackCooldown <= _lastAttackTime;

            if (!_canAttack)
            {
                _lastAttackTime += Time.deltaTime;
            }
        }

        public override void Fire()
        {
            if (!_canAttack)
            {
                return;
            }

            if (Physics.Raycast(_attackPosition.position, _attackPosition.forward, out var hitInfo, _attackDistance))
            {
                if (hitInfo.collider.TryGetComponent(out HealthComponent healthComponent))
                {
                    healthComponent.DealDamage(_damage);
                }
            }
            _lastAttackTime = 0f;
        }

        public override void Reload()
        {
            
        }
    }
}