using UnityEngine;

namespace Game
{
    public sealed class PlayerAudioController : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _stepSound;
        [SerializeField] private float _stepSoundDelay;
        [SerializeField] private float _sprintSoundDelay;
        [Range(0f, 1f)]
        [SerializeField] private float _volume = 1f;
        [Range(0f, 0.5f)]
        [SerializeField] private float _randomization = 0.1f;

        private PlayerController _playerController;
        private float _currentDelay;
        private float _lastStepTime;
        private bool _canPlay;

        private void Start()
        {
            _playerController = GetComponent<PlayerController>();
        }

        private void Update()
        {
            if (_playerController.isSprinting)
            {
                _currentDelay = _sprintSoundDelay;
            }
            else
            {
                _currentDelay = _stepSoundDelay;
            }

            _canPlay = _currentDelay <= _lastStepTime;

            if (!_canPlay)
            {
                _lastStepTime += Time.deltaTime;
            }
            else
            {
                PlayStepSound();
            }
        }

        private void PlayStepSound()
        {
            if (_playerController.isGrounded && _playerController.isMoving)
            {
                _audioSource.pitch = Random.Range(1f - _randomization, 1f + _randomization);
                _audioSource.volume = _volume;
                _audioSource.PlayOneShot(_stepSound);
                _lastStepTime = 0f;
            }
        }
    }
}