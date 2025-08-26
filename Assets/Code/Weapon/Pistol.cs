using UnityEngine;
using static Game.PistolData;

namespace Game
{
    public sealed class Pistol : Weapon, IReloadable, IReleasable
    {
        [SerializeField] private Transform _shootPosition;
        [SerializeField] private PistolData _weaponData;
        [SerializeField] private int _level = 1;
        [SerializeField] private float _shootDelay;
        [SerializeField] private int _ammo;

        #region
        private int _maxAmmo;
        private int _damage;
        #endregion

        private PistolUpgradeData _upgradeData;
        private float _lastShootTime;
        private bool _released;        
        private bool _canShoot;

        private void Start()
        {
            if (_weaponData.TryGetDataByLevel(_level, out _upgradeData))
            {
                _maxAmmo = _upgradeData.MaxAmmo;
                _damage = _upgradeData.Damage;
            }
            Reload();
            ReleaseTrigger();
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
            if (!_canShoot || !_released)
            {
                return;
            }

            if (_ammo > 0)
            {
                if (Physics.Raycast(_shootPosition.position, _shootPosition.forward, out var hitInfo))
                {
                    if (hitInfo.collider.TryGetComponent(out HealthComponent healthComponent))
                    {
                        healthComponent.DealDamage(_damage);
                    }
                }
                _ammo -= 1;
                _released = false;
                _lastShootTime = 0f;
            }
        }

        public void Reload()
        {
            _ammo = _maxAmmo;
        }

        public void ReleaseTrigger()
        {
            _released = true;
        }
    }
}