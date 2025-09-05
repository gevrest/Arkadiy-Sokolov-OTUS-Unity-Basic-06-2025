using UnityEngine;

namespace Game
{
    public sealed class Brick : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _renderer;

        private AudioController _audioController;
        private LevelController _levelController;

        private void Start()
        {
            _levelController = GetComponentInParent<LevelController>();
            _audioController = GetComponentInParent<AudioController>();
        }

        public void SetColor(Color color)
        {
            _renderer.material.color = color;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.TryGetComponent(out Ball ball))
            {
                _audioController.PlayPopSound();
                _levelController.CheckBricks();
                Destroy(gameObject);
            }
        }
    }
}