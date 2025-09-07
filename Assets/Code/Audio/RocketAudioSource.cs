using UnityEngine;

namespace Game
{
    public sealed class RocketAudioSource : MonoBehaviour
    {
        [SerializeField] private AudioClip _explosionSound;
        [Range(0.0f, 1.0f)]
        [SerializeField] private float _volume;

        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = gameObject.GetComponent<AudioSource>();
            _audioSource.volume = _volume;
        }

        public void PlayExplosionSound()
        {            
            _audioSource.PlayOneShot(_explosionSound);
        }
    }
}