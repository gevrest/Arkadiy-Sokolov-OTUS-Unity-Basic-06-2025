using UnityEngine;

namespace Game
{
    public sealed class PlayerAudioSource : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _stepSound;
        [SerializeField] private float _stepSoundDelay;
        [SerializeField] private float _sprintSoundDelay;
        [Range(0f, 1f)]
        [SerializeField] private float _volume = 1f;
        [Range(0f, 0.5f)]
        [SerializeField] private float _randomization = 0.1f;

        private CharacterController _characterController;
        private Vector3 _oldPosition;
        private float _currentDelay;
        private float _lastStepTime;
        private bool _canPlay;

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();

            _oldPosition = transform.position;
        }

        private void Update()
        {
            _canPlay = _currentDelay <= _lastStepTime;

            if (!_canPlay)
            {
                _lastStepTime += Time.deltaTime;
            }
            else
            {
                PlayStepSound();
            }
            _oldPosition = transform.position;
        }

        private void PlayStepSound()
        {
            if (_characterController.isGrounded && isMoving() == true)
            {
                _audioSource.pitch = Random.Range(1f - _randomization, 1f + _randomization);
                _audioSource.volume = _volume;
                _audioSource.PlayOneShot(_stepSound);
                _lastStepTime = 0f;
            }
        }

        private bool isMoving()
        {
            if (_oldPosition != transform.position)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SwitchToWalk()
        {
            _currentDelay = _stepSoundDelay;
        }

        public void SwitchToSprint()
        {
            _currentDelay = _sprintSoundDelay;
        }
    }
}