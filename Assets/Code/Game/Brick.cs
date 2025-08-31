using UnityEngine;

namespace Game
{
    public sealed class Brick : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _renderer;

        public void SetColor(Color color)
        {
            _renderer.material.color = color;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.TryGetComponent(out Ball ball))
            {
                Destroy(gameObject);
            }
        }
    }
}