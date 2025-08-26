using UnityEngine;
using static Game.AutomaticRifleData;

namespace Game
{
    public sealed class AutomaticRifle : Weapon, IReloadable
    {
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private AutomaticRifleData _weaponData;
        [SerializeField] private int _level = 1;
        [SerializeField] private int _ammo;

        #region
        private int _maxAmmo;
        private int _damage;
        private float _shootDelay;
        #endregion

        private ARUpgradeData _upgradeData;
        private float _lastShootTime;
        private bool _canShoot;

        private void Start()
        {
            if (_weaponData.TryGetDataByLevel(_level, out _upgradeData))
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

        public void Reload()
        {
            _ammo = _maxAmmo;
        }
    }
}