using UnityEngine;

namespace Game
{
    public class WeaponAudioSource : MonoBehaviour
    {
        [SerializeField] private AudioClip _shotSound;
        [Range(0f, 1f)]
        [SerializeField] private float _volume = 1f;
        [Range(0f, 0.5f)]
        [SerializeField] private float _randomization = 0.1f;

        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = transform.parent.GetComponentInChildren<AudioSource>();
            _audioSource.volume = _volume;
        }

        public void PlayShotSound()
        {
            _audioSource.volume = _volume;
            _audioSource.pitch = Random.Range(1f - _randomization, 1f + _randomization);
            _audioSource.PlayOneShot(_shotSound);
        }
    }
}