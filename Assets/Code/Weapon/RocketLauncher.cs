using UnityEngine;

namespace Game
{
    public sealed class RocketLauncher : Weapon
    {
        [SerializeField] private Transform _barrel;
        [SerializeField] private Rocket _rocketPrefab;
        [SerializeField] private float _force;

        private Rocket _rocket;
        private bool _canShoot;
        private bool _canReload = true;

        public override void Fire()
        {
            if (!_canShoot)
            {
                return;
            }

            _rocket.Strike(_barrel.forward * _force, _barrel.position);
            _canReload = true;
            _canShoot = false;
            _rocket = null;
        }

        public override void Reload()
        {
            if (!_canReload)
            {
                return;
            }

            _rocket = Instantiate(_rocketPrefab, _barrel.position, _barrel.rotation, _barrel);
            _rocket.Sleep(_barrel);
            _canReload = false;
            _canShoot = true;
        }
    }
}