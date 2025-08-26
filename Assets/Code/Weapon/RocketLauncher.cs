using UnityEngine;
using static Game.ExplosiveData;

namespace Game
{
    public sealed class RocketLauncher : Weapon, IReloadable
    {
        [SerializeField] private Transform _barrel;
        [SerializeField] private Rocket _rocketPrefab;
        [SerializeField] private ExplosiveData _weaponData;
        [SerializeField] private int _level = 1;

        private float _force;

        private ExplosiveUpgradeData _upgradeData;
        private Rocket _rocket;

        private void Start()
        {
            if (_weaponData.TryGetDataByLevel(_level, out _upgradeData))
            {
                _force = _upgradeData.Force;
            }
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

        public void Reload()
        {
            if (_rocket == null)
            {
                _rocket = Instantiate(_rocketPrefab, _barrel.position, _barrel.rotation, _barrel);
                _rocket.Sleep();
            }
        }
    }
}