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
            if (_isKilling && other.collider.TryGetComponent(out Ball ball))
            {
                _audioController.PlayDeathSound();
                _levelController.ResetLevel();
            }
        }
    }
}