using UnityEngine;

namespace Game
{
    public sealed class Border : MonoBehaviour
    {
        [SerializeField] private bool _isKilling;

        private LevelController _levelController;

        private void Start()
        {
            _levelController = GetComponentInParent<LevelController>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (_isKilling && other.collider.TryGetComponent(out Ball ball))
            {
                _levelController.ResetLevel();
            }
        }
    }
}