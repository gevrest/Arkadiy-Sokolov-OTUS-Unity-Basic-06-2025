using UnityEngine;
using static Game.AutomaticRifleData;

namespace Game
{
    public sealed class AutomaticRifle : Weapon
    {
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private AutomaticRifleData _automaticRifleData;
        [SerializeField] private int _level = 1;
        [SerializeField] private int _ammo;

        #region
        private int _maxAmmo;
        private int _damage;
        private float _shootDelay;
        #endregion

        private UpgradeData _upgradeData;
        private float _lastShootTime;
        private bool _canShoot;

        private void Start()
        {
            if (_automaticRifleData.TryGetDataByLevel(_level, out _upgradeData))
            {
                _maxAmmo = _upgradeData.MaxAmmo;
                _damage = _upgradeData.Damage;
                _shootDelay = _upgradeData.ShootDelay;
            }
            Reload();
        }

        private void Update()
        {
            _canShoot = _shootDelay <= _lastShootTime;

            if (!_canShoot)
            {
                _lastShootTime += Time.deltaTime;
            }
        }

        public override void Fire()
        {
            if (!_canShoot)
            {
                return;
            }

            if (_ammo > 0)
            {
                if (Physics.Raycast(_shootPoint.position, _shootPoint.forward, out var hitInfo))
                {
                    if (hitInfo.collider.TryGetComponent(out HealthComponent healthComponent))
                    {
                        healthComponent.DealDamage(_damage);
                    }
                }
                _ammo -= 1;
                _lastShootTime = 0f;
            }
        }

        public override void Reload()
        {
            _ammo = _maxAmmo;
        }

        public override void ReleaseTrigger()
        {
            throw new System.NotImplementedException();
        }
    }
}