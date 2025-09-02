using UnityEngine;

namespace Game
{
    public sealed class AudioController : MonoBehaviour
    {
        [SerializeField] AudioSource _levelAudioSource;
        [SerializeField] AudioSource _ambientAudioSource;
        [SerializeField] AudioClip _ambientClip;
        [SerializeField] AudioClip _popClip;
        [SerializeField] AudioClip _collisionClip;
        [SerializeField] AudioClip _deathClip;

        private void Update()
        {
            if (!_ambientAudioSource.isPlaying)
            {
                PlaySoundtrack();
            }
        }

        private void PlaySoundtrack()
        {
            _ambientAudioSource.clip = _ambientClip;
            _ambientAudioSource.Play();
        }

        public void PlayCollisionSound()
        {
            _levelAudioSource.PlayOneShot(_collisionClip);
        }

        public void PlayPopSound()
        {
            _levelAudioSource.PlayOneShot(_popClip);
        }

        public void PlayDeathSound()
        {
            _levelAudioSource.PlayOneShot(_deathClip);
        }
    }
}