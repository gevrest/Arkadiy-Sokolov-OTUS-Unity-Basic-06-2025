using UnityEngine;
using static Game.MeleeData;

namespace Game
{
    public class Melee : Weapon
    {
        [SerializeField] private Transform _attackPosition;
        [SerializeField] private MeleeData _weaponData;
        [SerializeField] private int _level = 1;

        #region
        private int _damage;
        private float _attackDistance;
        private float _attackCooldown;
        #endregion

        private MeleeUpgradeData _upgradeData;
        private float _lastAttackTime;
        private bool _canAttack;

        private void Start()
        {
            if (_weaponData.TryGetDataByLevel(_level, out _upgradeData))
            {
                _damage = _upgradeData.Damage;
                _attackDistance = _upgradeData.AttackDistance;
                _attackCooldown = _upgradeData.AttackCooldown;
            }
        }

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
    }
}