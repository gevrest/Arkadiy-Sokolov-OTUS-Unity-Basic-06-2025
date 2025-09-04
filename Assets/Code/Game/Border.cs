using UnityEngine;

namespace Game
{
    public sealed class Border : MonoBehaviour
    {
        [SerializeField] private bool _isKilling;

        private LevelController _levelController;
        private AudioController _audioController;

        private void Start()
        {
            _levelController = GetComponentInParent<LevelController>();
            _audioController = GetComponentInParent<AudioController>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.TryGetComponent(out Ball ball))
            {
                _audioController.PlayCollisionSound();

                if (_isKilling)
                {
                    _audioController.PlayDeathSound();
                    _levelController.ResetLevel();                    
                }
            }
        }
    }
}