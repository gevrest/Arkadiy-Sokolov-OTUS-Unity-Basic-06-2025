using UnityEngine;

namespace Game
{
    public sealed class Bonfire : MonoBehaviour
    {
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
            _bonfireLight.intensity = 1;

            isBurning = true;
        }

        private void Extinguish()
        {
            _particleSystem.Stop();
            _particleSystem.Clear();
            _audioSource.Stop();
            _bonfireLight.intensity = 0;

            isBurning = false;
        }
    }
}