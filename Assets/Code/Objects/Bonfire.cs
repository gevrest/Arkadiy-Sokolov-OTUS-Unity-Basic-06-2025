using UnityEngine;

namespace Game
{
    public sealed class Bonfire : MonoBehaviour
    {
        [SerializeField] private float _maxLightIntensity = 2.0f;
        [SerializeField] private float _minLightIntensity = 0.0f;
        [Space(10f)]
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private Light _bonfireLight;
        [SerializeField] private AudioSource _audioSource;

        public bool isBurning { get; private set; }

        private void Start()
        {
            _audioSource.Stop();
        }

        public void Switch()
        {
            if (!isBurning)
            {
                LightUp();
            }
            else
            {
                Extinguish();
            }
        }

        private void LightUp()
        {
            _particleSystem.Play();
            _audioSource.Play();
            _bonfireLight.intensity = _maxLightIntensity;

            isBurning = true;
        }

        private void Extinguish()
        {
            _particleSystem.Stop();
            _particleSystem.Clear();
            _audioSource.Stop();
            _bonfireLight.intensity = _minLightIntensity;

            isBurning = false;
        }
    }
}