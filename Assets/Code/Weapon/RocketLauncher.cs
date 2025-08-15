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

        private void Start()
        {
            Reload();
        }

        public override void Fire()
        {
            if (_rocket)
            {
                _rocket.Strike(_barrel.forward * _force, _barrel.position);
                _rocket = null;
            }
        }

        public override void Reload()
        {
            if (_rocket == null)
            {
                _rocket = Instantiate(_rocketPrefab, _barrel.position, _barrel.rotation, _barrel);
                _rocket.Sleep();
            }
        }
    }
}