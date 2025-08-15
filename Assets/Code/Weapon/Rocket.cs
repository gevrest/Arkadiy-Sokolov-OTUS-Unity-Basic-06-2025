using UnityEngine;

namespace Game
{
    public class Rocket : MonoBehaviour
    {
        [SerializeField] private float _explosionRadius;
        [SerializeField] private float _explosionForce;
        [SerializeField] private int _damage;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision other)
        {
            var explosion = gameObject.AddComponent<Explosion>();
            explosion.Detonate(transform.position, _explosionRadius, _explosionForce, _damage);
            Destroy(gameObject);
        }

        public bool IsActive { get; set; }

        public void Strike(Vector3 path, Vector3 startPosition)
        {
            transform.position = startPosition;
            gameObject.SetActive(true);
            _rigidbody.WakeUp();
            _rigidbody.AddForce(path);
            transform.SetParent(null);
        }

        public void Sleep()
        {
            _rigidbody.Sleep();
            gameObject.SetActive(false);
        }
    }
}