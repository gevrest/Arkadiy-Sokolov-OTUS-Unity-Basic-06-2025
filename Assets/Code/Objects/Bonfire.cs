using UnityEngine;

namespace Game
{
    public sealed class Bonfire : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private Light _bonfireLight;

        private void Start()
        {
            Kindle();
        }

        public void Kindle()
        {
            _particleSystem.Play();
            _audioSource.Play();
            _bonfireLight.intensity = 1;
        }

        public void Extinguish()
        {
            _particleSystem.Stop();
            _audioSource.Stop();
            _bonfireLight.intensity = 0;
        }
    }
}