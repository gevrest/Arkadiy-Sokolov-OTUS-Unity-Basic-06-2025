using UnityEngine;

namespace Game
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private int _ammo;
        [SerializeField] private int _maxAmmo;
        [SerializeField] private int _damage;
        [SerializeField] private float _shootDelay;

        private bool _canShoot;
        private float _lastShootTime;

        private void Update()
        {
            _canShoot = _shootDelay <= _lastShootTime;

            if (!_canShoot)
            {
                _lastShootTime += Time.deltaTime;
            }
        }

        public void Fire()
        {
            if (!_canShoot)
            {
                return;
            }

            if (_ammo > 0)
            {
                _ammo -= 1;
                _lastShootTime = 0f;

                Debug.DrawRay(_shootPoint.position, _shootPoint.forward, Color.red);

                if (Physics.Raycast(_shootPoint.position, _shootPoint.forward, out var hitInfo))
                {
                    if (hitInfo.collider.TryGetComponent(out HealthComponent healthComponent))
                    {
                        healthComponent.DealDamage(_damage);
                    }
                }
            }
        }

        public void Reload()
        {
            _ammo = _maxAmmo;
        }
    }
}