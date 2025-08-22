using UnityEngine;

namespace Game
{
    public sealed class Pistol : Weapon
    {
        [SerializeField] private Transform _shootPosition;
        [SerializeField] private int _ammo;
        [SerializeField] private int _maxAmmo;
        [SerializeField] private int _damage;
        [SerializeField] private float _shootDelay;

        private bool _released;
        private float _lastShootTime;
        private bool _canShoot;

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

        public override void Reload()
        {
            _ammo = _maxAmmo;
        }

        public override void ReleaseTrigger()
        {
            _released = true;
        }
    }
}