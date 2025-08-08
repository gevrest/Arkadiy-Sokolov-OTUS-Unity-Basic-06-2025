using UnityEngine;

namespace Game
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Transform _barrel;
        [SerializeField] private Rocket _rocket;
        [SerializeField] private int _countInClip;
        [SerializeField] private float _force;
        [SerializeField] private float _shotDelay;

        private Transform _rocketRoot;
        private Rocket[] _rockets;

        private void Start()
        {
            _rocketRoot = new GameObject("Rocket Root").transform;
            Reload();
        }

        public void Fire()
        {
            if (TryGetActiveRocket(out Rocket rocket))
            {
                rocket.Run(_barrel.forward *  _force, _barrel.position);
            }
        }

        private bool TryGetActiveRocket(out Rocket activeRocket)
        {
            int candidate = -1;
            activeRocket = default;

            if (_rockets == null)
            {
                return false;
            }

            for (int i = 0; i < _countInClip; i++)
            {
                Rocket rocket = _rockets[i];

                if (rocket == null)
                {
                    continue;
                }

                if (rocket.IsActive)
                {
                    return true;
                }

                candidate = i;
                break;
            }

            if (candidate == -1)
            {
                return false;
            }

            activeRocket = _rockets[candidate];
            return true;
        }

        public void Reload()
        {
            if (IsAnyActiveRocket())
            {
                return;
            }
            _rockets = new Rocket[_countInClip];
            for (int i = 0; i < _countInClip; i++)
            {
                Rocket rocket = Instantiate(_rocket, _rocketRoot);
                rocket.Sleep();
                _rockets[i] = rocket;
            }
        }

        private bool IsAnyActiveRocket()
        {
            if (_rockets == null)
            {
                return false;
            }

            for (int i = 0; i < _countInClip; i++)
            {
                Rocket rocket = _rockets[i];

                if (rocket == null)
                {
                    continue;
                }

                if (rocket.IsActive)
                {
                       return true;
                }
            }
            return false;
        }
    }
}